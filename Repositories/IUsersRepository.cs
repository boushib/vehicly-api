using System.Collections.Generic;
using vehiclesStoreAPI.DTO;
using vehiclesStoreAPI.Models;

namespace vehiclesStoreAPI.Repositories

{
  public interface IUsersRepository
  {
    bool IsAnExistingUser(string username);
    bool AreValidUserCredentials(string username, string password);
    List<string> GetUserRole(string username);
    void Signup(User user);
    bool SaveChanges();
  }
}