using Project3.Core;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Project3.Application
{
    public interface IUserManager
    {
        /// <summary>
        /// 取得使用者資訊
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        /// <exception cref="AppFriendlyException"></exception>
        Task<List<Claim>> GetUserWithPasswordAsync(string userName, string password, string language);

        /// <summary>
        /// 取得所有使用者
        /// </summary>
        /// <returns></returns>
        Task<List<SysUser>> GetUsersListAsync();

        /// <summary>
        /// 取得指定用戶的資訊
        /// </summary>
        /// <param name="id"></param>
        /// <param name="admin"></param>
        /// <returns></returns>
        Task<SysUser> GetUserByIdAsync(int id, bool admin = false);

        /// <summary>
        /// 建立新的用戶
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        Task<SysUser> CreateUserAsync(string loginName, string userName, string password, string email,
            string language = "zh-TW");

        /// <summary>
        /// 更新使用者資訊
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<SysUser> UpdateUserAsync(SysUser user);

        /// <summary>
        /// 刪除使用者
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteUserAsync(int id);

        /// <summary>
        /// 加入新的角色
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userRoleId"></param>
        /// <returns></returns>
        Task AddUserRoleAsync(int userId, int userRoleId);

        /// <summary>
        /// 移除角色
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userRoleId"></param>
        /// <returns></returns>
        Task RemoveUserRoleAsync(int userId, int userRoleId);

    }
}