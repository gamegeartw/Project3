using Project3.Application.Dtos;

namespace Project3.Application
{
    public interface IAdminService
    {
        Task<List<MenuItemDto>> GetSysMenuListAsync();
        Task<MenuItemDto> GetSysMenuAsync(long id);
        Task<List<MenuItemDto>> GetSubSysMenuListAsync(long id);
        Task UpdateSysMenuAsync(MenuItemDto menu);
        Task AddSysMenuAsync(InputMenuItemDto menu);
        Task DeleteSysMenuAsync(long id);

        /// <summary>
        /// 移動選單位置
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        Task MoveSysMenuAsync(long id, string type);
    }
}