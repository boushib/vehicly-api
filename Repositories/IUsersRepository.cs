using System.Collections.Generic;
using vehicly.Models;

namespace vehicly.Repositories;

public interface IUsersRepository
{
  bool IsAnExistingUser(string username);
  bool AreValidUserCredentials(string username, string password);
  List<string> GetUserRole(string username);
  void Signup(User user);
  bool SaveChanges();
}