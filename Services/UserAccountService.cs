namespace DependencyInjection.Services
{
    public class UserAccountService
    {
        private GoogleMailService _googlemailservice;

        public UserAccountService()
        {
            _googlemailservice = new GoogleMailService();
        }

        public string CreateUserAccount(string username, string password)
        {
            return $"User \"{username}\" has been created with Password \"{password}\".";
        }
    }
}