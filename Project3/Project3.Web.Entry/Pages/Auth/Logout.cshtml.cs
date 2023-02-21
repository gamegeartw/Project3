using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project3.Application;

namespace Project3.Web.Entry.Pages.Auth
{
    public class Logout : PageModel
    {
        public async void OnGetAsync()
        {
            await this.HttpContext.SignOutAsync();
        }
    }
}