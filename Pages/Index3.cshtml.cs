using Microsoft.AspNetCore.Mvc.RazorPages;
using DependencyInjection.Models;
using DependencyInjection.Services;
using DependencyInjection.Interfaces;

namespace DependencyInjection.Pages
{
    public class IndexModel3 : PageModel
    {
        public string PageTitle = "Constructor Injection";

        private UserAccount _useraccount;

        private UserAccountService _useraccountservice;

        private IEmailService _emailservice;

        public IndexModel3(IEmailService emailservice)
        {
            _useraccount = new UserAccount();
            _useraccountservice = new UserAccountService();
            _emailservice = emailservice;
        }
        public string UserConfirmation { get; set; }

        public string EmailConfirmation { get; set; }

        public string CreateNewEmail(string username)
        {
            return _emailservice.CreateMailAccount(username);
        }
        public void OnGet()
        {
            _useraccount.Username = "barry.allen";
            _useraccount.Password = "Flash";

            UserConfirmation = _useraccountservice.CreateUserAccount(_useraccount.Username, _useraccount.Password);

            GoogleMailService googleMailService = new GoogleMailService();
            IndexModel3 indexModel3 = new IndexModel3(googleMailService);
            EmailConfirmation = indexModel3.CreateNewEmail(_useraccount.Username);
        }
    }
}
