using Microsoft.AspNetCore.Mvc.RazorPages;
using DependencyInjection.Models;
using DependencyInjection.Services;

namespace DependencyInjection.Pages
{
    public class IndexModel2 : PageModel
    {
        public string PageTitle = "New Mail Service";

        private UserAccount _useraccount;

        private UserAccountService _useraccountservice;

        private OutlookMailService _outlookmailservice;

        public IndexModel2()
        {
            _useraccount = new UserAccount();
            _useraccountservice = new UserAccountService();
            _outlookmailservice = new OutlookMailService();
        }

        public string UserConfirmation { get; set; }

        public string EmailConfirmation { get; set; }

        public void OnGet()
        {
            _useraccount.Username = "clark.kent";
            _useraccount.Password = "Superman";

            UserConfirmation = _useraccountservice.CreateUserAccount(_useraccount.Username, _useraccount.Password);
            EmailConfirmation = _outlookmailservice.CreateMailAccount(_useraccount.Username);
        }
    }
}
