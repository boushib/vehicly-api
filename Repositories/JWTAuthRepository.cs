using System;
using System.Collections.Concurrent;
using System.Collections.Immutable;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;
using Microsoft.IdentityModel.Tokens;

namespace vehicly.Repositories;

public class JWTAuthRepository : IJWTAuthRepository
{
  private readonly JWTConfig _jwtConfig;

  private readonly byte[] _secret;

  // can be stored in a database or a distributed cache
  private readonly ConcurrentDictionary<string, RefreshToken> _userRefreshTokens;

  public JWTAuthRepository(JWTConfig jwtConfig)
  {
    _jwtConfig = jwtConfig;
    _userRefreshTokens = new ConcurrentDictionary<string, RefreshToken>();
    _secret = Encoding.ASCII.GetBytes(jwtConfig.Secret);
  }

  public IImmutableDictionary<string, RefreshToken> UserRefreshTokenDictionary =>
    _userRefreshTokens.ToImmutableDictionary();

  public (ClaimsPrincipal, JwtSecurityToken) DecodeJWT(string token)
  {
    if (string.IsNullOrWhiteSpace(token)) throw new SecurityTokenException("Invalid token");
    var principal = new JwtSecurityTokenHandler()
      .ValidateToken(token, new TokenValidationParameters
        {
          ValidateIssuer = true,
          ValidIssuer = _jwtConfig.Issuer,
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey(_secret),
          ValidAudience = _jwtConfig.Audience,
          ValidateAudience = true,
          ValidateLifetime = true,
          ClockSkew = TimeSpan.FromMinutes(1)
        },
        out var validatedToken);
    return (principal, validatedToken as JwtSecurityToken);
  }

  public JWTAuthResult GenerateTokens(string username, Claim[] claims, DateTime now)
  {
    var shouldAddAudienceClaim =
      string.IsNullOrEmpty(claims?.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Aud)?.Value);
    var jwt = new JwtSecurityToken(
      _jwtConfig.Issuer,
      shouldAddAudienceClaim ? _jwtConfig.Audience : "", claims,
      expires: now.AddMinutes(_jwtConfig.AccessTokenExpiration),
      signingCredentials: new SigningCredentials(new SymmetricSecurityKey(_secret),
        SecurityAlgorithms.HmacSha256Signature));
    var accessToken = new JwtSecurityTokenHandler().WriteToken(jwt);
    var refreshToken = new RefreshToken
    {
      Username = username,
      TokenString = GenerateRefreshTokenString(),
      ExpireAt = now.AddMinutes(_jwtConfig.RefreshTokenExpiration)
    };
    _userRefreshTokens.AddOrUpdate(refreshToken.TokenString, refreshToken, (s, t) => refreshToken);
    return new JWTAuthResult
    {
      AccessToken = accessToken,
      RefreshToken = refreshToken
    };
  }

  public JWTAuthResult Refresh(string refreshToken, string accessToken, DateTime now)
  {
    var (principal, jwt) = DecodeJWT(accessToken);
    if (jwt == null || !jwt.Header.Alg.Equals(SecurityAlgorithms.HmacSha256Signature))
      throw new SecurityTokenException("Invalid Token");
    if (_userRefreshTokens.TryGetValue(refreshToken, out var existingRefreshToken))
      throw new SecurityTokenException("Invalid Token");
    var username = principal.Identity.Name;
    if (existingRefreshToken.Username != username || existingRefreshToken.ExpireAt < now)
      throw new SecurityTokenException("Ivalid Token");
    // recover original claims
    return GenerateTokens(username, principal.Claims.ToArray(), now);
  }

  public void RemoveExpiredRefreshTokens(DateTime now)
  {
    var expiredTokens = _userRefreshTokens.Where(token => token.Value.ExpireAt < now).ToList();
    foreach (var token in expiredTokens) _userRefreshTokens.TryRemove(token.Key, out _);
  }

  public void RemoveRefreshTokensByUsername(string username)
  {
    var refreshTokens = _userRefreshTokens.Where(token => token.Value.Username == username).ToList();
    foreach (var token in refreshTokens) _userRefreshTokens.TryRemove(token.Key, out _);
  }

  public static string GenerateRefreshTokenString()
  {
    var random = new byte[32];
    var randomGen = RandomNumberGenerator.Create();
    randomGen.GetBytes(random);
    return Convert.ToBase64String(random);
  }
}

public class RefreshToken
{
  [JsonPropertyName("username")] public string Username { get; set; }

  [JsonPropertyName("tokenString")] public string TokenString { get; set; }

  [JsonPropertyName("expireAt")] public DateTime ExpireAt { get; set; }
}

public class JWTAuthResult
{
  [JsonPropertyName("accessToken")] public string AccessToken { get; set; }

  [JsonPropertyName("refreshToken")] public RefreshToken RefreshToken { get; set; }
}