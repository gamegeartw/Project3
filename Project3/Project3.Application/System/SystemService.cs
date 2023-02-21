using Microsoft.AspNetCore.Authentication.JwtBearer;
using Project3.Application.Dtos;
using Project3.Core;

namespace Project3.Application
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SystemService : ISystemService, IDynamicApiController, ITransient
    {
        private readonly IRepository<SysUser> _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SystemService(
            IRepository<SysUser> userRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
        }


        public string GetDescription()
        {
            return "让 .NET 开发更简单，更通用，更流行。";
        }

        /// <summary>
        /// 取得側邊選單
        /// </summary>
        /// <returns></returns>
        public async Task<MenuItemDto[]> GetMenuItemsAsync(long userId)
        {
            InitialMenuExtraData();


            var user = await _userRepository
                .Include(m => m.SysMenus)
                .ThenInclude(m => m.Children)
                .Include(m => m.SysRoles)
                .ThenInclude(m => m.SysMenus)
                .ThenInclude(m => m.Children)
                .FirstOrDefaultAsync(m => m.Id == userId);

            if (user == null)
            {
                throw Oops.Oh("用戶不存在");
            }

            var menus = new List<SysMenu>();
            if (user.SysMenus != null)
            {
                menus.AddRangeIfNotContains(user.SysMenus.Where(m => !m.ParentId.HasValue).ToList());
            }

            if (user.SysRoles.Count != 0)
            {
                var roles = user.SysRoles.OfType<SysRole>().Select(m => m.Id).ToArray();

                menus.AddRangeIfNotContains(user.SysRoles.SelectMany(m => m.SysMenus).Where(m => !m.ParentId.HasValue).ToList());

                foreach (var menu in menus)
                {
                    menu.Children = menu.Children
                        ?.Where(m => m.SysRoles != null && m.SysRoles.Any(r => roles.Contains(r.Id))).OrderBy(m => m.Index).ToList();
                }
            }

            var items = menus.OrderBy(m => m.ParentId).ThenBy(m => m.Index).Adapt<IEnumerable<MenuItemDto>>().ToArray();

            return items;
        }


        /// <summary>
        /// 初始化選單資料,只有第一次執行才會執行,補齊資料,以後就不會再執行了
        /// </summary>
        private void InitialMenuExtraData()
        {
            // if (_userRepository.SqlScalar<int>("Select count(*) from SysRoleSysUser") == 0)
            // {
            //     // 寫入Admin角色跟選單
            //     _userRepository.SqlNonQuery(@"INSERT INTO SysRoleSysUser (SysRolesId, SysUsersId) VALUES (1, 1)");
            //     _userRepository.SqlNonQuery(@"INSERT INTO SysMenuSysRole (SysRolesId, SysMenusId) VALUES (1, 1)");
            //     _userRepository.SqlNonQuery(@"INSERT INTO SysMenuSysRole (SysRolesId, SysMenusId) VALUES (1, 2)");
            //     _userRepository.SqlNonQuery(@"INSERT INTO SysMenuSysRole (SysRolesId, SysMenusId) VALUES (1, 3)");
            //     _userRepository.SqlNonQuery(@"INSERT INTO SysMenuSysRole (SysRolesId, SysMenusId) VALUES (1, 4)");
            //     _userRepository.SqlNonQuery(@"INSERT INTO SysMenuSysRole (SysRolesId, SysMenusId) VALUES (1, 5)");
            //     _userRepository.SqlNonQuery(@"INSERT INTO SysMenuSysRole (SysRolesId, SysMenusId) VALUES (1, 6)");
            //
            //     // 寫入user角色跟選單
            //     _userRepository.SqlNonQuery(@"INSERT INTO SysRoleSysUser (SysRolesId, SysUsersId) VALUES (2, 2)");
            //     _userRepository.SqlNonQuery(@"INSERT INTO SysMenuSysRole (SysRolesId, SysMenusId) VALUES (2, 1)");
            // }
        }
    }
}