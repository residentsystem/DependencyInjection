using DependencyInjection.Interfaces;

namespace DependencyInjection.Services
{
    public class GoogleMailService : IEmailService
    {
        public string CreateMailAccount(string username)
        {
            var domain = "@gmail.com";
            return $"\nEmail \"{username}{domain}\" has been created successfuly.\n";
        }
    }
}