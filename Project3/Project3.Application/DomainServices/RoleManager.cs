using Project3.Core;

namespace Project3.Application
{
    public class RoleManager : IRoleManager, ITransient
    {
        private readonly IRepository<SysRole> _repo;

        public RoleManager(IRepository<SysRole> repo)
        {
            _repo = repo;
        }
        public Task<List<SysRole>> GetRolesListAsync()
        {
            return _repo.Entities.ToListAsync();
        }

        public Task<SysRole> GetRoleByIdAsync(long id)
        {
            return _repo.FindAsync(id);
        }

        public Task<SysRole> CreateRoleAsync(SysRole role)
        {
            return Task.FromResult(_repo.Insert(role).Entity);
        }

        public Task<SysRole> UpdateRoleAsync(SysRole role)
        {
            return Task.FromResult(_repo.Update(role).Entity);
        }

        public Task DeleteRoleAsync(long id)
        {
            return _repo.DeleteAsync(id);
        }
    }
}