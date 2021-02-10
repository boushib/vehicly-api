namespace vehiclesStoreAPI.Repositories
{
  public interface IUserRepository
  {
    bool IsAnExistingUser(string username);
    bool AreValidUserCredentials(string username, string password);
    string GetUserRole(string username);
  }
}