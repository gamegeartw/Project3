using Furion.DatabaseAccessor.Extensions;
using Project3.Application.Dtos;
using Project3.Core;

namespace Project3.Application
{
    public class AdminService : ITransient, IAdminService
    {
        private readonly IRoleManager _roleManager;
        private readonly IRepository<SysMenu> _repo;

        public AdminService(
            IRoleManager roleManager,
            IRepository<SysMenu> repo)
        {
            _roleManager = roleManager;
            _repo = repo;
        }

        public Task<List<MenuItemDto>> GetSysMenuListAsync()
        {
            return _repo.Entities.ProjectToType<MenuItemDto>().OrderBy(m => m.ParentId).ThenBy(m => m.Index).ToListAsync();
        }

        public Task<MenuItemDto> GetSysMenuAsync(long id)
        {
            return _repo.Entities.Include(m => m.SysRoles).Include(m => m.SysUsers).ProjectToType<MenuItemDto>()
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public Task<List<MenuItemDto>> GetSubSysMenuListAsync(long id)
        {
            return _repo.Entities.Include(m => m.Parent).Where(m => m.ParentId == id).ProjectToType<MenuItemDto>()
                .ToListAsync();
        }

        public Task UpdateSysMenuAsync(MenuItemDto menu)
        {
            var sysMenu = _repo.Find(menu.Id);
            menu.Adapt(sysMenu);
            return _repo.UpdateAsync(sysMenu);
        }

        public async Task AddSysMenuAsync(InputMenuItemDto menu)
        {
            var sysMenu = menu.Adapt<SysMenu>();
            if (sysMenu.ParentId.HasValue)
            {
                var parent = await _repo.FindAsync(sysMenu.ParentId.Value);
                sysMenu.Parent = parent;
                var children = (await GetSubSysMenuListAsync(parent.Id)).LastOrDefault();
                if (children != null)
                {
                    sysMenu.Index = children.Index + 1;
                }
                else
                {
                    sysMenu.Index = 1;
                }
            }
            else
            {
                var last = (await GetSysMenuListAsync()).Last(m => !m.ParentId.HasValue);
                sysMenu.Index = last.Index + 1;
            }

            var roles = new List<SysRole>();
            foreach (var idx in menu.Roles)
            {
                roles.Add(await _roleManager.GetRoleByIdAsync(idx));
            }

            sysMenu.SysRoles = roles;
            await _repo.InsertAsync(sysMenu);
        }

        public async Task DeleteSysMenuAsync(long id)
        {
            var sysMenu = await _repo.Include(m => m.Children).FirstOrDefaultAsync(m => m.Id == id);
            if (sysMenu.Children != null && sysMenu.Children.Any())
            {
                throw Oops.Oh("該選單下還有子選單，請先刪除子選單");
            }

            await _repo.DeleteNowAsync(sysMenu);
            var list = sysMenu.ParentId.HasValue ?
                _repo.Where(m => m.ParentId == sysMenu.ParentId).OrderBy(m => m.Index).ToList() :
                _repo.Where(m => !m.ParentId.HasValue).OrderBy(m => m.Index).ToList();
            for (int i = 0; i < list.Count; i++)
            {
                list[i].Index = i + 1;
                await _repo.UpdateNowAsync(list[i]);
            }
        }

        public Task MoveSysMenuAsync(long id, string type)
        {
            var sysMenu = _repo.Find(id);
            List<SysMenu> list;
            list = sysMenu.ParentId.HasValue ?
                _repo.Where(m => m.ParentId == sysMenu.ParentId).OrderBy(m => m.Index).ToList() :
                _repo.Where(m => !m.ParentId.HasValue).OrderBy(m => m.Index).ToList();

            var idx = list.IndexOf(sysMenu);
            switch (type)
            {
                case "up": //上移
                    if (idx == 1 && !sysMenu.ParentId.HasValue) throw Oops.Oh("已經是第一個了(首頁位置不能被佔用)");
                    var upper = list[idx - 1];
                    upper.Index += 1;
                    sysMenu.Index -= 1;
                    upper.Update();
                    sysMenu.Update();
                    break;
                case "down": //下移
                    if (idx == list.Count - 1) throw Oops.Oh("已經是最後一個了");
                    var lower = list[idx + 1];
                    lower.Index -= 1;
                    sysMenu.Index += 1;
                    sysMenu.Update();
                    break;
                case "prev": //上一層
                    if (!sysMenu.ParentId.HasValue) throw Oops.Oh("已經是最上層了");
                    var parent = _repo.Find(sysMenu.ParentId.Value);
                    if (parent.ParentId.HasValue)
                    {
                        list = _repo.Where(m => m.ParentId == parent.ParentId).OrderBy(m => m.Index).ToList();
                        var last = list.Last();
                        sysMenu.ParentId = parent.ParentId;
                        sysMenu.Index = last.Index + 1;
                    }
                    else
                    {
                        list = _repo.Where(m => m.ParentId == null).OrderBy(m => m.Index).ToList();
                        sysMenu.ParentId = null;
                        sysMenu.Index = list.Last().Index + 1;
                    }

                    break;
            }

            return Task.CompletedTask;
        }
    }
}