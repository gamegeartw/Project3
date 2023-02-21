using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project3.Core
{
    public class SysUser : CommonEntity<long>, IEntityTypeBuilder<SysUser>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override long Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string LoginName { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

        public string Avatar { get; set; }

        public string Language { get; set; }
        public virtual ICollection<SysRole> SysRoles { get; set; }

        public virtual ICollection<SysMenu> SysMenus { get; set; }

        public void Configure(EntityTypeBuilder<SysUser> entityBuilder, DbContext dbContext, Type dbContextLocator)
        {
            //entityBuilder.Property(m => m.Id).HasField("UserId");
            entityBuilder.HasQueryFilter(m => !m.IsDeleted);

            entityBuilder.HasData(new List<SysUser>()
        {
            new ()
            {
                Id = 1,
                UserName = "admin",
                Language = "zh-TW",
                LoginName = "admin",
                Password = "admin0000".ToSHA256(),
                CreatedBy = "system",
                Email = "admin@admin.com"
            },
            new ()
            {
                Id = 2,
                UserName = "user",
                Language = "zh-TW",
                LoginName = "user",
                Password = "user0000".ToSHA256(),
                CreatedBy = "system",
                Email = "user@user.com"
            }
        });

            // entityBuilder.
            //     HasMany<SysRole>(s=>s.SysRoles).
            //     WithMany(s=>s.SysUsers).
            //     UsingEntity(j=>j.ToTable("SysUserRole"));
            //
            // entityBuilder.HasMany<SysMenu>(s=>s.SysMenus)
            //     .WithMany(s=>s.SysUsers).UsingEntity(j=>j.ToTable("SysUserMenu"));
        }
    }
}