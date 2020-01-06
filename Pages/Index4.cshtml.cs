using Microsoft.AspNetCore.Mvc.RazorPages;
using DependencyInjection.Models;
using DependencyInjection.Services;
using DependencyInjection.Interfaces;

namespace DependencyInjection.Pages
{
    public class IndexModel4 : PageModel
    {
        public string PageTitle = "Setter Injection";

        private UserAccount _useraccount;

        private UserAccountService _useraccountservice;

        private IEmailService _emailservice;

        public IndexModel4()
        {
            _useraccount = new UserAccount();
            _useraccountservice = new UserAccountService();
        }

        public IEmailService EmailService {
            get {
                return _emailservice;
            }
            set {
                _emailservice = value;
            }
        }

        public string UserConfirmation { get; set; }
        
        public string EmailConfirmation { get; set; }

        public void OnGet()
        {
            _useraccount.Username = "diana.prince";
            _useraccount.Password = "WonderWomen";

            UserConfirmation = _useraccountservice.CreateUserAccount(_useraccount.Username, _useraccount.Password);

            GoogleMailService googleMailService = new GoogleMailService();
            EmailService = googleMailService;
            EmailConfirmation = EmailService.CreateMailAccount(_useraccount.Username);
        }
    }
}
