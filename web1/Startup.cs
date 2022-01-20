using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Piranha;
using Piranha.AspNetCore.Identity.MySQL;
using Piranha.AspNetCore.Identity.SQLite;
using Piranha.AttributeBuilder;
using Piranha.Data.EF.MySql;
using Piranha.Data.EF.SQLite;
using Piranha.Manager.Editor;
using System;
using System.IO;
using web1.Models.Blocks;

namespace web1
{
    public class Startup
    {
        private readonly IConfiguration _config;
        private readonly IWebHostEnvironment _environment;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="configuration">The current configuration</param>
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            _config = configuration;
            _environment = environment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDataProtection().PersistKeysToFileSystem(new DirectoryInfo("./keys"));
            // Service setup
            services.AddPiranha(options =>
            {
                options.UseFileStorage(naming: Piranha.Local.FileStorageNaming.UniqueFolderNames);
                options.UseImageSharp();
                options.UseManager();
                options.UseTinyMCE();
                options.UseMemoryCache();
                if (_environment.IsDevelopment())
                {
                    var connectionString = _config.GetConnectionString("piranha");
                    options.UseEF<SQLiteDb>(db => db.UseSqlite(connectionString));
                    options.UseIdentity<IdentitySQLiteDb>(db => db.UseSqlite(connectionString));
                }
                else
                {
                    var connectionString = _config.GetConnectionString("LocalMySqlServer");
                    options.UseEF<MySqlDb>(db =>
                        db.UseMySql(connectionString));
                    options.UseIdentity<IdentityMySQLDb>(db =>
                        db.UseMySql(connectionString),
                        identityOptions: io =>
                        {
                        // Password settings
                        io.Password.RequireDigit = false;
                            io.Password.RequiredLength = 6;
                            io.Password.RequireNonAlphanumeric = false;
                            io.Password.RequireUppercase = false;
                            io.Password.RequireLowercase = false;
                            io.Password.RequiredUniqueChars = 1;

                        // Lockout settings
                        io.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                            io.Lockout.MaxFailedAccessAttempts = 10;
                            io.Lockout.AllowedForNewUsers = true;

                        // User settings
                        io.User.RequireUniqueEmail = true;
                        },
                        cookieOptions: co =>
                        {
                            co.Cookie.HttpOnly = false;
                            co.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                            co.LoginPath = "/manager/login";
                            co.AccessDeniedPath = "/manager/login";
                            co.SlidingExpiration = true;
                        }
                    );
                }
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IApi api, Config config)
        {
            if (_environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            config.CommentsEnabledForPosts = false;
            // Initialize Piranha
            App.Init(api);

            // Build content types
            new ContentTypeBuilder(api)
                .AddAssembly(typeof(Startup).Assembly)
                .Build()
                .DeleteOrphans();
            App.Blocks.Register<YoutubeBlock>();
            App.Blocks.Register<ActionBlock>();
            App.Blocks.Register<EventBlock>();
            App.MediaTypes.Documents.Add(".css", "text/css");
            // Configure Tiny MCE
            EditorConfig.FromFile("editorconfig.json");

            // Middleware setup
            app.UsePiranha(options =>
            {
                options.UseManager();
                options.UseTinyMCE();
                options.UseIdentity();
            });
        }
    }
}