using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project3.Core
{
    public class SysMenu : CommonEntity<long>, IEntityTypeBuilder<SysMenu>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override long Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Icon { get; set; }

        public string Url { get; set; }

        public virtual ICollection<SysMenu> Children { get; set; }

        public virtual SysMenu Parent { get; set; }


        public virtual long Index { get; set; }


        [ForeignKey("Id")]
        [Column("ParentId")]
        public long? ParentId { get; set; }


        public virtual ICollection<SysRole> SysRoles { get; set; }

        public virtual ICollection<SysUser> SysUsers { get; set; }

        public void Configure(EntityTypeBuilder<SysMenu> entityBuilder, DbContext dbContext, Type dbContextLocator)
        {
            entityBuilder.HasQueryFilter(m => !m.IsDeleted);

            entityBuilder.HasOne(m => m.Parent)
                .WithMany(m => m.Children)
                .HasForeignKey("ParentId")
                .OnDelete(DeleteBehavior.Restrict);

            entityBuilder.HasData(new List<SysMenu>()
        {
            new()
            {
                Id = 1,
                Title = "首頁",
                Icon = "fa fa-home",
                Url = "/main",
                IsDeleted = false,
                CreatedBy = "admin",
                Index = 1
            },
            new()
            {
                Id = 2,
                Title = "系統選單",
                Icon = "fa fa-list",
                Url = "#",
                IsDeleted = false,
                CreatedBy = "admin",
                Index = 2


            },
            new()
                {
                    Id = 3,
                    Title = "人員管理",
                    Icon = "fa fa-user",
                    Url = "/admin/users",
                    IsDeleted = false,
                    ParentId = 2,
                    CreatedBy = "admin",
                    Index = 1
                },
            new()
            {
                Id = 4,
                Title = "角色管理",
                Icon = "fa fa-users",
                Url = "/admin/roles",
                IsDeleted = false,
                ParentId = 2,
                CreatedBy = "admin",
                Index = 2
            },
            new()
            {
                Id = 5,
                Title = "權限管理",
                Icon = "fa fa-lock",
                Url = "/admin/permission",
                IsDeleted = false,
                ParentId = 2,
                CreatedBy = "admin",
                Index = 3

            },
            new()
            {
                Id = 6,
                Title = "系統選單管理",
                Icon = "fa fa-list",
                Url = "/admin/menus",
                IsDeleted = false,
                ParentId = 2,
                CreatedBy = "admin",
                Index = 4
            }

        });

            // entityBuilder.
            //     HasMany<SysRole>(s => s.SysRoles).
            //     WithMany(m => m.SysMenus).
            //     UsingEntity(j => j.ToTable("SysRoleMenu"));
        }
    }
}