
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using mywep.API.Data;
using roadrunnerapi.Data;
using roadrunnerapi.Helpers;
using roadrunnerapi.Services.EmployeeService;

namespace roadrunnerapi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

   public IConfiguration Configuration { get; }

        // public void ConfigureDevelopmentServices(IServiceCollection services)
        // {
        //     services.AddDbContext<DataContext>(x => {
        //         x.UseLazyLoadingProxies();
        //         x.UseSqlite(Configuration.GetConnectionString("DefaultConnetion"));
        //     });

        //     ConfigureServices(services);
        // }

        
        // public void ConfigureProductionServices(IServiceCollection services)
        // {
        //     services.AddDbContext<DataContext>(x => {
        //         x.UseLazyLoadingProxies();
        //         x.UseMySql("Server=localhost;Port=3306;Database=rdb;Uid=appuser;Pwd=roadrun@2020");
        //         // x.UseSqlServer("Server=tcp:roadrun.database.windows.net,1433;Initial Catalog=rdb;Persist Security Info=False;User ID=appuser;Password=roadrun@2020;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30");
        //     });

        //     ConfigureServices(services);
        // }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<DataContext>(x => {
                x.UseLazyLoadingProxies();
               // x.UseMySql("Server=localhost;Port=3306;Database=rdb;Uid=appuser;Pwd=roadrun@2020");
                x.UseSqlServer(Configuration.GetConnectionString("DefaultConnetion"));
                
            });

            services.Configure<CloudinarySettings>(Configuration.GetSection("CloudinarySettings"));
            services.AddAutoMapper(typeof(DRepositary).Assembly);
            services.AddScoped<IAuthRepository,AuthRepository>();
            services.AddScoped<IDRepositary,DRepositary>();
              
              services.AddScoped<IEmployeeService,EmployeeService>();
            services.AddControllers().AddNewtonsoftJson(opt =>{
                opt.SerializerSettings.ReferenceLoopHandling =
                Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            });
             services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => {
            options.TokenValidationParameters = new TokenValidationParameters{
                ValidateIssuerSigningKey =true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                ValidateIssuer = false,
                ValidateAudience = false

                    };

            });
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

          //  app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
              app.UseCors(x=> x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapFallbackToController("Index","Fallback");
            });
        }
    }
}
