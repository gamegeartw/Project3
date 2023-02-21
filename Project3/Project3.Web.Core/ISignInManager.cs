using System.Threading.Tasks;

namespace Project3.Web.Core
{
    public interface ISignInManager
    {
        /// <summary>
        /// 登入
        /// </summary>
        /// <param name="context"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="remember"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        Task SignInAsync(string userName, string password, bool remember = true, string language = "zh-TW");

        /// <summary>
        /// 登出
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        Task SignOutAsync();
    }
}