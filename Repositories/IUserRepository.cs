using System.Collections.Generic;

namespace vehiclesStoreAPI.Repositories

{
  public interface IUserRepository
  {
    bool IsAnExistingUser(string username);
    bool AreValidUserCredentials(string username, string password);
    List<string> GetUserRole(string username);
  }
}