using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Budget.DATA;
using Budget.SERVICE;
using Budget.DATA.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Budget.API.Helpers;
using AutoMapper;
using Budget.SERVICE.GMap;
using Budget.DATA.Repositories.GMap;
using Budget.DATA.Repositories.ContextTransaction;
using Microsoft.EntityFrameworkCore;
using Budget.HELPER;
using Budget.MODEL.Dto;
using Microsoft.AspNetCore.Identity;
using Budget.MODEL.Mailing;
using Budget.MODEL;
using Newtonsoft.Json;

namespace Budget.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private readonly IOptions<CloudinarySettings> _cloudinaryConfig;

        public Startup(IConfiguration configuration,
            IOptions<CloudinarySettings> cloudinaryConfig)
        {
            Configuration = configuration;
            _cloudinaryConfig = cloudinaryConfig;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //TrustServerCertificate = True

            //var DefaultConnexion = CryptoHelper.Encrypt("Server = 172.20.60.11; Database = XmlToSwift_Demo; Trusted_Connection = True; MultipleActiveResultSets = true");
            //var DefaultConnexion = CryptoHelper.Encrypt("Server = SQLDEVGD; Database = XmlToSwift_Demo; Trusted_Connection = True; MultipleActiveResultSets = true");
            //var DefaultConnexion = CryptoHelper.Encrypt("Server = PS10; Database = XmlToSwift_Demo; Trusted_Connection = True; MultipleActiveResultSets = true");
            //var DefaultConnexion = CryptoHelper.Encrypt("Server = nl1-wsq1.a2hosting.com; Database = monbudge_budget; user=monbudge_budget; password=9A3xit4m?");
            //var DefaultConnexion = CryptoHelper.Encrypt(@"Server = DESKTOP-0M47AE3\SQLEXPRESS; Database = Budget; Trusted_Connection = True; MultipleActiveResultSets = true");
            //var DefaultConnexion = CryptoHelper.Encrypt(@"Server = DESKTOP-29ARAIO\SQLEXPRESS; Database = Budget; Trusted_Connection = True; MultipleActiveResultSets = true");
            //var DefaultConnexion = CryptoHelper.Encrypt(@"Server = 172.20.60.11; Database = XmlToSwift_Demo; Trusted_Connection = True;TrustServerCertificate = True; MultipleActiveResultSets = true");

            //var CloudName = CryptoHelper.Encrypt("killmeagain77"); 
            //var ApiKey = CryptoHelper.Encrypt("867256855236325");
            //var ApiSecret = CryptoHelper.Encrypt("8XeXYsOBLHKvSn0FcvaLuTw862Y");
            //var Token = CryptoHelper.Encrypt("some_big_key_value_here_secret");

            //var decrypt = CryptoHelper.Decrypt(Configuration.GetConnectionString("DefaultConnexion"));
            //var defaultconnection = CryptoHelper.Decrypt(Configuration.GetConnectionString("DefaultConnexion"));
            ////Add context DB

            //services.AddDbContext<BudgetContext>(options =>
            //    options.UseSqlServer(CryptoHelper.Decrypt(Configuration.GetConnectionString("DefaultConnexion"))));

            //Add identity
            //services.AddIdentity<IdentityUser, IdentityRole>()
            //    .AddEntityFrameworkStores<BudgetContext>();
            //.AddDefaultTokenProviders();

            //services.AddIdentityServer().AddDeveloperSigningCredential()
            //      // this adds the operational data from DB (codes, tokens, consents)
            //      .AddOperationalStore(options =>
            //      {
            //          options.ConfigureDbContext = builder => builder.UseSqlServer(Configuration.GetConnectionString("Default"));
            //          // this enables automatic token cleanup. this is optional.
            //          options.EnableTokenCleanup = true;
            //          options.TokenCleanupInterval = 30; // interval in seconds
            //      })
            //      .AddInMemoryIdentityResources(Config.GetIdentityResources())
            //      .AddInMemoryApiResources(Config.GetApiResources())
            //      .AddInMemoryClients(Config.GetClients())
            //      .AddAspNetIdentity<AppUser>();

            //Add Cors
            services.AddCors();
            services.Configure<CloudinarySettings>(Configuration.GetSection("CloudinarySettings"));

            var tutu = Configuration.GetSection("AppSettings")["Token"];
            var tata = Configuration.GetSection("CloudinarySettings");
            var toto = Configuration.GetSection("AppSettings");


            

            services.AddLazyResolution();

            //services.AddAutoMapper();
            services.RegisterService(Configuration);
                      

            //services.AddTransient<IGreeter, Greeter>();

            //add authentification
            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Token").Value);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
            
            services.AddAuthorization(options =>
                options.AddPolicy("Admin",
                    policy => policy.RequireClaim("Admin")));
            //Identity
            //services.AddIdentity<UserForLoginDto, IdentityRole>(opt =>
            //{
            //    opt.Password.RequiredLength = 7;
            //    opt.Password.RequireDigit = false;
            //    opt.Password.RequireUppercase = false;

            //    opt.User.RequireUniqueEmail = true;

            //    opt.SignIn.RequireConfirmedEmail = true;
            //});

            services.AddMvcCore()
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
            //services.AddMvc().AddJsonOptions(opt =>
            //{
            //    opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            //});

            //services.AddAuthorization(config =>
            //{
            //    config.AddPolicy(Policies.Admin, Policies.AdminPolicy());
            //    config.AddPolicy(Policies.User, Policies.UserPolicy());
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                var toto = _cloudinaryConfig.Value;
                //Add our new middleware to the pipeline
                //app.UseMiddleware<RequestTrackerMiddleware>();
                //Add Cors
                app.UseCors(builder =>
                {
                    builder.WithOrigins(Configuration.GetSection("Cors")["Url"])
                    .AllowAnyHeader().AllowAnyMethod().AllowCredentials();
                });

                app.UseRouting();
                app.UseAuthentication();
                app.UseAuthorization();
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });

                ////app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

                ////Add Authentication
                //app.UseAuthentication();

                ////Add Mvc
                ////app.UseMvc();
                //app.UseRouting();
            }
            else
            {
                app.UseExceptionHandler(builder =>
                {
                    builder.Run(async context =>
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                        var error = context.Features.Get<IExceptionHandlerFeature>();
                        if (error != null)
                        {
                            context.Response.AddApplicationError(error.Error.Message);
                            await context.Response.WriteAsync(error.Error.Message);
                        }
                    });
                });

                //Add our new middleware to the pipeline
                //app.UseMiddleware<RequestTrackerMiddleware>();
                //Add Cors
                app.UseCors(builder =>
                {
                    builder.WithOrigins(Configuration.GetSection("Cors")["Url"])
                    .AllowAnyHeader().AllowAnyMethod().AllowCredentials();
                });
                //app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

                //Add Authentication
                app.UseAuthentication();

                //utilisation du wwwRoot pour production:
                app.UseDefaultFiles();
                app.UseStaticFiles();

                //app.UseMvc(routes =>
                //{
                //    routes.MapSpaFallbackRoute(
                //        name: "spa-fallback",
                //        defaults: new { controller = "Fallback", action = "Index" }
                //        );
                //});
                
            }

            //app.UseHttpsRedirection();

            ////Add our new middleware to the pipeline
            //app.UseMiddleware<RequestTrackerMiddleware>();
            ////Add Cors
            //app.UseCors(builder =>
            //{
            //    builder.WithOrigins("http://localhost:4200")
            //    .AllowAnyHeader().AllowAnyMethod().AllowCredentials();
            //});
            ////app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            ////Add Authentication
            //app.UseAuthentication();

            ////utilisation du wwwRoot pour production:
            //app.UseDefaultFiles();
            //app.UseStaticFiles();
            //app.UseMvc(routes =>
            //{
            //    routes.MapSpaFallbackRoute(
            //        name:"spa-fallback",
            //        defaults: new {controller = "Fallback", action="Index"}
            //        );
            //});
            //--


            //sans utilisation root:
            //app.UseMvc();
        }
    }
}
