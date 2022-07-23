namespace vehicly.Repositories;

public class JWTConfig
{
  public string Secret { get; set; }

  public string Issuer { get; set; }

  public string Audience { get; set; }

  public int AccessTokenExpiration { get; set; }

  public int RefreshTokenExpiration { get; set; }
}