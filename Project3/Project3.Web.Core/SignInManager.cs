using Furion.DependencyInjection;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Project3.Application;
using Project3.Core;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Project3.Web.Core
{
    public class SignInManager : ITransient, ISignInManager
    {
        private readonly IUserManager _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SignInManager(
            IUserManager userManager,
            IHttpContextAccessor httpContextAccessor
            )
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// 登入
        /// </summary>
        /// <param name="context"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="remember"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public async Task SignInAsync(string userName, string password, bool remember = true, string language = "zh-TW")
        {
            var claims = await _userManager.GetUserWithPasswordAsync(userName, $"{userName}{password}".ToSHA256(), language);

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,
                new AuthenticationProperties()
                {
                    IsPersistent = remember,
                    RedirectUri = "/Index",
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30),

                });
        }


        /// <summary>
        /// 登出
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Task SignOutAsync()
        {
            return _httpContextAccessor.HttpContext.SignOutAsync();
        }
    }
}