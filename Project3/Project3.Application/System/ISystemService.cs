using Project3.Application.Dtos;

namespace Project3.Application
{
    public interface ISystemService
    {
        [Authorize(Roles = "admin,user")]
        string GetDescription();

        /// <summary>
        /// 取得側邊選單
        /// </summary>
        /// <param name="userId">使用者Id</param>
        /// <returns></returns>
        Task<MenuItemDto[]> GetMenuItemsAsync(long userId);
    }
}