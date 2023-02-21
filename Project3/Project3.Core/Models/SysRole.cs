using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project3.Core
{
    public class SysRole : CommonEntity<long>, IEntityTypeBuilder<SysRole>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override long Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("Id")]
        public long? ParentId { get; set; }

        public virtual SysRole Parent { get; set; }

        public virtual ICollection<SysRole> Children { get; set; }

        public virtual ICollection<SysUser> SysUsers { get; set; }

        public virtual ICollection<SysMenu> SysMenus { get; set; }

        public void Configure(EntityTypeBuilder<SysRole> entityBuilder, DbContext dbContext, Type dbContextLocator)
        {
            //entityBuilder.Property(m => m.Id).HasField("RoleId");
            entityBuilder.HasQueryFilter(m => !m.IsDeleted);
            entityBuilder.HasOne(m => m.Parent)
                .WithMany(m => m.Children)
                .HasForeignKey("ParentId")
                .OnDelete(DeleteBehavior.Restrict);
            entityBuilder.HasData(new List<SysRole>()
        {
            new ()
            {
                Id = 1,
                Name = "admin"
            },
            new()
            {
                Id = 2,
                Name = "user"
            }
        });
        }
    }
}