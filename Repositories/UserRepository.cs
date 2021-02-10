using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace vehiclesStoreAPI.Repositories
{
  public class UserRepository : IUserRepository
  {
    private readonly ILogger<UserRepository> _logger;
    private readonly IDictionary<string, string> _users = new Dictionary<string, string>{
      {"admin", "123456"},
      {"el", "123456"},
    };

    public UserRepository(ILogger<UserRepository> logger)
    {
      _logger = logger;
    }

    public bool AreValidUserCredentials(string username, string password)
    {
      _logger.LogInformation($"Checking [{username}] credentials");
      if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
      {
        return false;
      }
      return _users.TryGetValue(username, out var p) && p == password;
    }

    public List<string> GetUserRole(string username)
    {
      var roles = new List<string>() { UserRole.USER };
      if (username == "admin") roles.Add(UserRole.ADMIN);
      return roles;
    }

    public bool IsAnExistingUser(string username)
    {
      return _users.ContainsKey(username);
    }
  }

  public static class UserRole
  {
    public const string USER = "user";
    public const string ADMIN = "admin";
  }
}