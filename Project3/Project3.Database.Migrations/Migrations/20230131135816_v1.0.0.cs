using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project3.Database.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class v100 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SysMenu",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Icon = table.Column<string>(type: "TEXT", nullable: true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    Index = table.Column<long>(type: "INTEGER", nullable: false),
                    ParentId = table.Column<long>(type: "INTEGER", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysMenu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SysMenu_SysMenu_ParentId",
                        column: x => x.ParentId,
                        principalTable: "SysMenu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SysRole",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    ParentId = table.Column<long>(type: "INTEGER", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SysRole_SysRole_ParentId",
                        column: x => x.ParentId,
                        principalTable: "SysRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SysUser",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    LoginName = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    Phone = table.Column<string>(type: "TEXT", nullable: true),
                    Avatar = table.Column<string>(type: "TEXT", nullable: true),
                    Language = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SysMenuSysRole",
                columns: table => new
                {
                    SysMenusId = table.Column<long>(type: "INTEGER", nullable: false),
                    SysRolesId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysMenuSysRole", x => new { x.SysMenusId, x.SysRolesId });
                    table.ForeignKey(
                        name: "FK_SysMenuSysRole_SysMenu_SysMenusId",
                        column: x => x.SysMenusId,
                        principalTable: "SysMenu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SysMenuSysRole_SysRole_SysRolesId",
                        column: x => x.SysRolesId,
                        principalTable: "SysRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SysMenuSysUser",
                columns: table => new
                {
                    SysMenusId = table.Column<long>(type: "INTEGER", nullable: false),
                    SysUsersId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysMenuSysUser", x => new { x.SysMenusId, x.SysUsersId });
                    table.ForeignKey(
                        name: "FK_SysMenuSysUser_SysMenu_SysMenusId",
                        column: x => x.SysMenusId,
                        principalTable: "SysMenu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SysMenuSysUser_SysUser_SysUsersId",
                        column: x => x.SysUsersId,
                        principalTable: "SysUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SysRoleSysUser",
                columns: table => new
                {
                    SysRolesId = table.Column<long>(type: "INTEGER", nullable: false),
                    SysUsersId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysRoleSysUser", x => new { x.SysRolesId, x.SysUsersId });
                    table.ForeignKey(
                        name: "FK_SysRoleSysUser_SysRole_SysRolesId",
                        column: x => x.SysRolesId,
                        principalTable: "SysRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SysRoleSysUser_SysUser_SysUsersId",
                        column: x => x.SysUsersId,
                        principalTable: "SysUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SysMenu",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "Description", "Icon", "Index", "IsDeleted", "ParentId", "Title", "UpdatedBy", "UpdatedTime", "Url" },
                values: new object[,]
                {
                    { 1L, "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "fa fa-home", 1L, false, null, "首頁", null, null, "/main" },
                    { 2L, "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "fa fa-list", 2L, false, null, "系統選單", null, null, "#" }
                });

            migrationBuilder.InsertData(
                table: "SysRole",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "IsDeleted", "Name", "ParentId", "UpdatedBy", "UpdatedTime" },
                values: new object[,]
                {
                    { 1L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "admin", null, null, null },
                    { 2L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "user", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "SysUser",
                columns: new[] { "Id", "Avatar", "CreatedBy", "CreatedTime", "Email", "IsDeleted", "Language", "LoginName", "Password", "Phone", "UpdatedBy", "UpdatedTime", "UserName" },
                values: new object[,]
                {
                    { 1L, null, "system", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", false, "zh-TW", "admin", "53D6316BD7B9044E6BB5DEAA87FE8316C2FDE3938B78F8448875B08E551CCC95", null, null, null, "admin" },
                    { 2L, null, "system", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@user.com", false, "zh-TW", "user", "3B67CE04F53C9208F1B29449EE071628DC72C5A3B1DA35734DEDE2D7C6A91ABF", null, null, null, "user" }
                });

            migrationBuilder.InsertData(
                table: "SysMenu",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "Description", "Icon", "Index", "IsDeleted", "ParentId", "Title", "UpdatedBy", "UpdatedTime", "Url" },
                values: new object[,]
                {
                    { 3L, "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "fa fa-user", 1L, false, 2L, "人員管理", null, null, "/admin/users" },
                    { 4L, "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "fa fa-users", 2L, false, 2L, "角色管理", null, null, "/admin/roles" },
                    { 5L, "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "fa fa-lock", 3L, false, 2L, "權限管理", null, null, "/admin/permission" },
                    { 6L, "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "fa fa-list", 4L, false, 2L, "系統選單管理", null, null, "/admin/menus" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SysMenu_ParentId",
                table: "SysMenu",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_SysMenuSysRole_SysRolesId",
                table: "SysMenuSysRole",
                column: "SysRolesId");

            migrationBuilder.CreateIndex(
                name: "IX_SysMenuSysUser_SysUsersId",
                table: "SysMenuSysUser",
                column: "SysUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_SysRole_ParentId",
                table: "SysRole",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_SysRoleSysUser_SysUsersId",
                table: "SysRoleSysUser",
                column: "SysUsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SysMenuSysRole");

            migrationBuilder.DropTable(
                name: "SysMenuSysUser");

            migrationBuilder.DropTable(
                name: "SysRoleSysUser");

            migrationBuilder.DropTable(
                name: "SysMenu");

            migrationBuilder.DropTable(
                name: "SysRole");

            migrationBuilder.DropTable(
                name: "SysUser");
        }
    }
}
