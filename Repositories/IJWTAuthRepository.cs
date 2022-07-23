using System;
using System.Collections.Immutable;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace vehicly.Repositories;

public interface IJWTAuthRepository
{
  IImmutableDictionary<string, RefreshToken> UserRefreshTokenDictionary { get; }

  JWTAuthResult GenerateTokens(string username, Claim[] claims, DateTime now);
  JWTAuthResult Refresh(string refreshToken, string accessToken, DateTime now);
  void RemoveExpiredRefreshTokens(DateTime now);
  void RemoveRefreshTokensByUsername(string username);
  (ClaimsPrincipal, JwtSecurityToken) DecodeJWT(string token);
}