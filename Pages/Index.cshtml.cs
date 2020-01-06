using Microsoft.AspNetCore.Mvc.RazorPages;
using DependencyInjection.Models;
using DependencyInjection.Services;

namespace DependencyInjection.Pages
{
    public class IndexModel : PageModel
    {
        public string PageTitle = "Dependency Injection";

        private UserAccount _useraccount;

        private UserAccountService _useraccountservice;

        private GoogleMailService _googlemailservice;

        public IndexModel()
        {
            _useraccount = new UserAccount();
            _useraccountservice = new UserAccountService();
            _googlemailservice = new GoogleMailService();
        }

        public string UserConfirmation { get; set; }

        public string EmailConfirmation { get; set; }

        public void OnGet()
        {
            _useraccount.Username = "bruce.wayne";
            _useraccount.Password = "Batman";

            UserConfirmation = _useraccountservice.CreateUserAccount(_useraccount.Username, _useraccount.Password);
            EmailConfirmation = _googlemailservice.CreateMailAccount(_useraccount.Username);
        }
    }
}
