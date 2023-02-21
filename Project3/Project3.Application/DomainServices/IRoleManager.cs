using Project3.Core;

namespace Project3.Application
{
    public interface IRoleManager
    {
        /// <summary>
        /// 取得所有角色
        /// </summary>
        /// <returns></returns>
        Task<List<SysRole>> GetRolesListAsync();

        /// <summary>
        /// 取得角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<SysRole> GetRoleByIdAsync(long id);

        /// <summary>
        /// 新增角色
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        Task<SysRole> CreateRoleAsync(SysRole role);

        /// <summary>
        /// 更新角色
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        Task<SysRole> UpdateRoleAsync(SysRole role);

        /// <summary>
        /// 刪除角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteRoleAsync(long id);

    }
}