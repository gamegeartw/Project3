using Furion.DatabaseAccessor.Extensions;
using Furion.Localization;
using Project3.Core;
using System.Security.Claims;

namespace Project3.Application
{
    public class UserManager : ITransient, IUserManager
    {
        private readonly IRepository<SysRole> _roleRepository;
        private readonly IRepository<SysUser> _userRepository;

        public UserManager(
            IRepository<SysRole> roleRepository,
            IRepository<SysUser> userRepository)
        {
            _roleRepository = roleRepository;
            _userRepository = userRepository;
        }

        /// <summary>
        /// 取得使用者資訊
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        /// <exception cref="AppFriendlyException"></exception>
        public async Task<List<Claim>> GetUserWithPasswordAsync(string userName, string password, string language)
        {
            var user = await _userRepository
                .Include(m => m.SysMenus)
                .Include(m => m.SysRoles)
                .ThenInclude(m => m.SysMenus)
                .ThenInclude(m => m.Children)
                .Where(u => (u.LoginName == userName || u.Email == userName) && u.Password == password)
                .FirstOrDefaultAsync();
            if (user == null)
            {
                throw Oops.Oh(L.Text["UserNameOrPasswordError"]);
            }

            user.Language = language;
            await _userRepository.UpdateAsync(user);

            return await GetClaimsAsync(user);
        }

        public Task<List<SysUser>> GetUsersListAsync()
        {
            //return _userRepository.Entities.ToListAsync();
            return _userRepository.SqlQueryAsync<SysUser>("Select * from SysUser");
        }

        public Task<SysUser> GetUserByIdAsync(int id, bool admin = false)
        {
            if (admin)
            {
                return Task.FromResult(_userRepository.SqlQuery<SysUser>("Select * from SysUser where Id=@id", new { id }).First());
            }

            return _userRepository.FindAsync(id);
        }


        public async Task<SysUser> CreateUserAsync(string loginName, string userName, string password, string email,
            string language = "zh-TW")
        {
            return (await _userRepository.InsertAsync(new SysUser
            {
                LoginName = loginName,
                UserName = userName,
                Password = password,
                Email = email,
                Language = language
            })).Entity;
        }

        public async Task<SysUser> UpdateUserAsync(SysUser user)
        {
            await user.UpdateIncludeAsync(new[] { nameof(SysUser.Password), nameof(SysUser.UserName), nameof(SysUser.Email), nameof(SysUser.Phone) }, true);
            return user;
        }

        public Task DeleteUserAsync(int id)
        {
            if (id == Convert.ToInt32(App.User.FindFirstValue(ClaimTypes.NameIdentifier)))
            {
                throw Oops.Oh("不可刪除自己");
            }
            return _userRepository.DeleteAsync(id);
        }

        public async Task AddUserRoleAsync(int userId, int userRoleId)
        {
            var user = await _userRepository.Include(m => m.SysRoles).FirstAsync(m => m.Id == userId);
            if (user.SysRoles.Any(m => m.Id == userRoleId)) throw Oops.Oh("已經有此角色");

            var role = await _roleRepository.FindAsync(userRoleId);
            user.SysRoles.Add(role);
            await user.UpdateAsync();
        }

        public async Task RemoveUserRoleAsync(int userId, int userRoleId)
        {
            var user = await _userRepository.Include(m => m.SysRoles).FirstAsync(m => m.Id == userId);
            if (user.SysRoles.Any(m => m.Id != userRoleId)) throw Oops.Oh("角色不存在");
            user.SysRoles.Remove(user.SysRoles.First(m => m.Id == userRoleId));
            await user.UpdateAsync();
        }


        private Task<List<Claim>> GetClaimsAsync(SysUser user)
        {
            var claims = new List<Claim>
        {
            new(ClaimTypes.Name, user.UserName),
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Email, user.Email),
            new(ClaimTypes.Locality, user.Language)
        };

            foreach (var role in user.SysRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Name));
            }
            return Task.FromResult(claims);
        }
    }
}