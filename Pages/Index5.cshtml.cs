using Microsoft.AspNetCore.Mvc.RazorPages;
using DependencyInjection.Models;
using DependencyInjection.Services;
using DependencyInjection.Interfaces;

namespace DependencyInjection.Pages
{
    public class IndexModel5 : PageModel
    {
        public string PageTitle = "Method Injection";

        private UserAccount _useraccount;

        private UserAccountService _useraccountservice;

        public IndexModel5()
        {
            _useraccount = new UserAccount();
            _useraccountservice = new UserAccountService();
        }

        public string UserConfirmation { get; set; }
        
        public string EmailConfirmation { get; set; }

        public string CreateNewEmail(IEmailService emailservice, string username)
        {
            return emailservice.CreateMailAccount(username);
        }

        public void OnGet()
        {
            _useraccount.Username = "oliver.queen";
            _useraccount.Password = "GreenArrow";

            UserConfirmation = _useraccountservice.CreateUserAccount(_useraccount.Username, _useraccount.Password);

            GoogleMailService googleMailService = new GoogleMailService();
            IndexModel5 indexModel5 = new IndexModel5();
            EmailConfirmation = indexModel5.CreateNewEmail(googleMailService, _useraccount.Username);
        }
    }
}
