using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using vehiclesStoreAPI.DAO;
using vehiclesStoreAPI.DTO;
using vehiclesStoreAPI.Models;

namespace vehiclesStoreAPI.Repositories
{
  public class UsersRepository : IUsersRepository
  {
    private readonly ILogger<UsersRepository> _logger;
    private readonly UsersContext _context;
    private readonly IDictionary<string, string> _users = new Dictionary<string, string>{
      {"admin", "123456"},
      {"el", "123456"},
    };

    public UsersRepository(UsersContext context, ILogger<UsersRepository> logger)
    {
      _context = context;
      _logger = logger;
    }

    public void Signup(User user)
    {
      if (user == null) throw new ArgumentNullException(nameof(user));
      _context.Users.Add(user);
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

    public bool SaveChanges()
    {
      return _context.SaveChanges() >= 0;
    }
  }

  public static class UserRole
  {
    public const string USER = "user";
    public const string ADMIN = "admin";
  }
}