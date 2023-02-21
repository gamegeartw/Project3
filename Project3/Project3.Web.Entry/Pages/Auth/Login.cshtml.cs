using Furion.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project3.Web.Core;
using System.ComponentModel.DataAnnotations;

namespace Project3.Web.Entry.Pages.Auth
{
    public class LoginModel : PageModel
    {
        private readonly ILogger<LoginModel> _logger;
        private readonly ISignInManager _signInManager;

        [BindProperty]
        public LoginInput InputData { get; set; }

        public LoginModel(
            ILogger<LoginModel> logger,
            ISignInManager signInManager
            )
        {
            _logger = logger;
            _signInManager = signInManager;
        }


        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _signInManager.SignInAsync(
                        InputData.UserName,
                        InputData.Password,
                        InputData.RememberMe,
                        InputData.Language);
                    L.SetCurrentUICulture(InputData.Language);
                    return Page();
                }
            }
            catch (Exception e)
            {
                _logger.LogError("登入失敗", e);
                //return new JsonResult(new ResultViewModel("500", e.Message));
                ModelState.AddModelError("登入失敗", e.Message);
            }

            return Page();
        }

        public class LoginInput
        {
            [Required][Display(Name = "帳號")] public string UserName { get; set; }
            [Required][Display(Name = "密碼")] public string Password { get; set; }

            public string Language { get; set; }
            [Display(Name = "記住我")] public bool RememberMe { get; set; }
        }
    }
}