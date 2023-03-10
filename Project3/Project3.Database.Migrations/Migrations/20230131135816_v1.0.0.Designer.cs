// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project3.EntityFramework.Core;
using System;

#nullable disable

namespace Project3.Database.Migrations.Migrations
{
    [DbContext(typeof(DefaultDbContext))]
    [Migration("20230131135816_v1.0.0")]
    partial class v100
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("SysMenuSysRole", b =>
                {
                    b.Property<long>("SysMenusId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("SysRolesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("SysMenusId", "SysRolesId");

                    b.HasIndex("SysRolesId");

                    b.ToTable("SysMenuSysRole");
                });

            modelBuilder.Entity("SysMenuSysUser", b =>
                {
                    b.Property<long>("SysMenusId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("SysUsersId")
                        .HasColumnType("INTEGER");

                    b.HasKey("SysMenusId", "SysUsersId");

                    b.HasIndex("SysUsersId");

                    b.ToTable("SysMenuSysUser");
                });

            modelBuilder.Entity("SysRoleSysUser", b =>
                {
                    b.Property<long>("SysRolesId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("SysUsersId")
                        .HasColumnType("INTEGER");

                    b.HasKey("SysRolesId", "SysUsersId");

                    b.HasIndex("SysUsersId");

                    b.ToTable("SysRoleSysUser");
                });

            modelBuilder.Entity("Project3.Core.SysMenu", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Icon")
                        .HasColumnType("TEXT");

                    b.Property<long>("Index")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("ParentId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("ParentId");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("SysMenu");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedBy = "admin",
                            CreatedTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Icon = "fa fa-home",
                            Index = 1L,
                            IsDeleted = false,
                            Title = "首頁",
                            Url = "/main"
                        },
                        new
                        {
                            Id = 2L,
                            CreatedBy = "admin",
                            CreatedTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Icon = "fa fa-list",
                            Index = 2L,
                            IsDeleted = false,
                            Title = "系統選單",
                            Url = "#"
                        },
                        new
                        {
                            Id = 3L,
                            CreatedBy = "admin",
                            CreatedTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Icon = "fa fa-user",
                            Index = 1L,
                            IsDeleted = false,
                            ParentId = 2L,
                            Title = "人員管理",
                            Url = "/admin/users"
                        },
                        new
                        {
                            Id = 4L,
                            CreatedBy = "admin",
                            CreatedTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Icon = "fa fa-users",
                            Index = 2L,
                            IsDeleted = false,
                            ParentId = 2L,
                            Title = "角色管理",
                            Url = "/admin/roles"
                        },
                        new
                        {
                            Id = 5L,
                            CreatedBy = "admin",
                            CreatedTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Icon = "fa fa-lock",
                            Index = 3L,
                            IsDeleted = false,
                            ParentId = 2L,
                            Title = "權限管理",
                            Url = "/admin/permission"
                        },
                        new
                        {
                            Id = 6L,
                            CreatedBy = "admin",
                            CreatedTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Icon = "fa fa-list",
                            Index = 4L,
                            IsDeleted = false,
                            ParentId = 2L,
                            Title = "系統選單管理",
                            Url = "/admin/menus"
                        });
                });

            modelBuilder.Entity("Project3.Core.SysRole", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<long?>("ParentId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("SysRole");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Name = "admin"
                        },
                        new
                        {
                            Id = 2L,
                            CreatedTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Name = "user"
                        });
                });

            modelBuilder.Entity("Project3.Core.SysUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Avatar")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Language")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("SysUser");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedBy = "system",
                            CreatedTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "admin@admin.com",
                            IsDeleted = false,
                            Language = "zh-TW",
                            LoginName = "admin",
                            Password = "53D6316BD7B9044E6BB5DEAA87FE8316C2FDE3938B78F8448875B08E551CCC95",
                            UserName = "admin"
                        },
                        new
                        {
                            Id = 2L,
                            CreatedBy = "system",
                            CreatedTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "user@user.com",
                            IsDeleted = false,
                            Language = "zh-TW",
                            LoginName = "user",
                            Password = "3B67CE04F53C9208F1B29449EE071628DC72C5A3B1DA35734DEDE2D7C6A91ABF",
                            UserName = "user"
                        });
                });

            modelBuilder.Entity("SysMenuSysRole", b =>
                {
                    b.HasOne("Project3.Core.SysMenu", null)
                        .WithMany()
                        .HasForeignKey("SysMenusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project3.Core.SysRole", null)
                        .WithMany()
                        .HasForeignKey("SysRolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SysMenuSysUser", b =>
                {
                    b.HasOne("Project3.Core.SysMenu", null)
                        .WithMany()
                        .HasForeignKey("SysMenusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project3.Core.SysUser", null)
                        .WithMany()
                        .HasForeignKey("SysUsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SysRoleSysUser", b =>
                {
                    b.HasOne("Project3.Core.SysRole", null)
                        .WithMany()
                        .HasForeignKey("SysRolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project3.Core.SysUser", null)
                        .WithMany()
                        .HasForeignKey("SysUsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Project3.Core.SysMenu", b =>
                {
                    b.HasOne("Project3.Core.SysMenu", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("Project3.Core.SysRole", b =>
                {
                    b.HasOne("Project3.Core.SysRole", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("Project3.Core.SysMenu", b =>
                {
                    b.Navigation("Children");
                });

            modelBuilder.Entity("Project3.Core.SysRole", b =>
                {
                    b.Navigation("Children");
                });
#pragma warning restore 612, 618
        }
    }
}
