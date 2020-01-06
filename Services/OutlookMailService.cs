using DependencyInjection.Interfaces;

namespace DependencyInjection.Services
{
    public class OutlookMailService : IEmailService
    {
        public string CreateMailAccount(string username)
        {
            string domain = "@outlook.com";
            return $"\nEmail \"{username}{domain}\" has been created successfuly.\n";
        }
    }
}