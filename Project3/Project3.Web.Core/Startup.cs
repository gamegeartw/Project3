using Furion;
using Furion.DatabaseAccessor;
using Furion.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Project3.Core;
using Project3.EntityFramework.Core;

namespace Project3.Web.Core
{
    public class Startup : AppStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddConsoleFormatter();
            services.AddSignalR();
            // 啟用認證,這裡使用混合驗證
            services.AddJwt(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
                CookieAuthenticationDefaults.AuthenticationScheme,
                options =>
                {
                    options.LoginPath = new PathString("/Auth/Login");
                    options.LogoutPath = new PathString("/Index");
                    options.AccessDeniedPath = new PathString("/Auth/AccessDenied");
                });


            services.AddCorsAccessor();
            services.AddControllers().AddInjectWithUnifyResult().AddAppLocalization();
            services.AddRazorPages(options =>
            {
                options.Conventions.AuthorizeFolder("/");
                options.Conventions.AllowAnonymousToFolder("/Auth");
                options.Conventions.AuthorizeFolder("/admin", "RequireAdmin");
            });
            // 授權的策略,
            services.AddAuthorization(options =>
            {
                // 增加一條策略,角色是Admin的成員會被賦予RequireAdmin
                options.AddPolicy("RequireAdmin", policy => policy.RequireRole("admin"));
                // 自訂策略,若Claim裡有沒有一個Over18且值是true的Flag,就賦予Over18
                options.AddPolicy("Over18", policy => policy.RequireClaim("Over18", "true"));
            });
            services.AddVirtualFileServer();

            services.AddHttpContextAccessor();

            services.AddScoped<MyRazorFilterAttribute>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                Scoped.Create((_, scope) =>
                {
                    var userRepository = scope.ServiceProvider.GetService<IRepository<SysUser>>();


                    if (userRepository.SqlScalar<int>("Select count(*) from SysMenuSysRole") == 0)
                    {
                        // 寫入Admin角色跟選單
                        userRepository.SqlNonQuery(@"INSERT INTO SysRoleSysUser (SysRolesId, SysUsersId) VALUES (1, 1)");
                        userRepository.SqlNonQuery(@"INSERT INTO SysMenuSysRole (SysRolesId, SysMenusId) VALUES (1, 1)");
                        userRepository.SqlNonQuery(@"INSERT INTO SysMenuSysRole (SysRolesId, SysMenusId) VALUES (1, 2)");
                        userRepository.SqlNonQuery(@"INSERT INTO SysMenuSysRole (SysRolesId, SysMenusId) VALUES (1, 3)");
                        userRepository.SqlNonQuery(@"INSERT INTO SysMenuSysRole (SysRolesId, SysMenusId) VALUES (1, 4)");
                        userRepository.SqlNonQuery(@"INSERT INTO SysMenuSysRole (SysRolesId, SysMenusId) VALUES (1, 5)");
                        userRepository.SqlNonQuery(@"INSERT INTO SysMenuSysRole (SysRolesId, SysMenusId) VALUES (1, 6)");

                        // 寫入user角色跟選單
                        userRepository.SqlNonQuery(@"INSERT INTO SysRoleSysUser (SysRolesId, SysUsersId) VALUES (2, 2)");
                        userRepository.SqlNonQuery(@"INSERT INTO SysMenuSysRole (SysRolesId, SysMenusId) VALUES (2, 1)");
                    }
                });
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseAppLocalization(); //增加多語系

            app.UseMyCustomMiddleware();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseInject();
            app.UseVirtualFileServer();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHubs();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}