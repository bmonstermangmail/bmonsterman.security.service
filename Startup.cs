
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using bmonsterman.security.service.Data;
using bmonsterman.security.service.Services;
using Microsoft.AspNetCore.Identity;
using bmonsterman.security.service.Entities;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace bmonsterman.security.service
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;            
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers()
                    .AddNewtonsoftJson(options => {
                        options.UseCamelCasing(true);
                    });
            
            var dbUserName = Configuration["security-db-username"];
            var dbPassword = Configuration["security-db-password"];
            var dbHost = Configuration["security-db-host"];

            services.AddDbContext<SecurityDbContext>(
                options => options.UseSqlServer($"Server={dbHost};Database=Security;User Id={dbUserName};Password={dbPassword}")
            );          

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "bmonsterman.security.service", Version = "v1" });
            });

            // Adds out of the box authentication
            services.AddIdentityCore<User>(options =>
            {
                options.SignIn.RequireConfirmedEmail = true;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            }).AddRoles<Role>()
              .AddEntityFrameworkStores<SecurityDbContext>()
              .AddSignInManager<SigninManager>()
              .AddUserManager<UserManager>()
              .AddDefaultTokenProviders();

            services.TryAddScoped<IUserManager, UserManager>();
            services.TryAddScoped<ISignInManager, SigninManager>();  

            services.AddAuthentication();
            services.AddDataProtection();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "bmonsterman.security.service v1"));
            }
            
            app.UseRouting();
            
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
