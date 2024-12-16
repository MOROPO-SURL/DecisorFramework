using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MOROPO.Framework.Decisor.Core.Presentation.Web.Backend.Extensions;
using MOROPO.Framework.Decisor.Core.Presentation.Web.Common.Extensions;
using MOROPO.Framework.Decisor.Core.Presentation.Web.Frontend.Options;
using MOROPO.Framework.Decisor.Domain.Presentation.Web.Common.Extensions;
using MOROPO.Framework.Decisor.Financial.Presentation.Web.Common.Extensions;
using MOROPO.Framework.Decisor.HumanResources.Presentation.Web.Backend.Extensions;
using MOROPO.Framework.Decisor.HumanResources.Presentation.Web.Common.Extensions;
using MOROPO.Framework.Decisor.Legal.Presentation.Web.Common.Extensions;
using MOROPO.Framework.Decisor.Servicing.Presentation.Web.Backend.Extensions;
using MOROPO.Framework.Decisor.Servicing.Presentation.Web.Common.Extensions;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Core.Security.Common.Presentation.Web.Frontend.Extensions;
using MOROPO.Framework.Guama.Location.Presentation.Web.Common.Extensions;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Extensions;
using MOROPO.Framework.Guama.Security.Personal.Persistence.ORM.EF.Extensions;
using MOROPO.Framework.Guama.Security.Personal.Presentation.Web.Backend.Extensions;
using Serilog;
using System.Linq;

namespace MOROPO.EPTCamaguey.Decisor.Web.BackOffice
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        private readonly IWebHostEnvironment env;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();

            this.configuration = configuration;
            this.env = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<Framework.Guama.Media.Presentation.Web.Common.Options.RelativeMediaFileManagementOptions>(configuration.GetSection("FileManagement"));
            services.Configure<JwtOptions>(configuration.GetSection("JWT"));

            services.AddDbContext<Persistence.ORM.EF.Context.ApplicationDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<DbContext, Persistence.ORM.EF.Context.ApplicationDbContext>();

            services.PerformCoreWebSecurityCommonFrontendServiceRegistration();
            services.PerformSecurityPersonalWebBackendServiceRegistration();
            services.PerformMediaWebCommonRelativePathFileManagementServiceRegistration();
            services.PerformLocationWebCommonServiceRegistration();

            services.AddDecisorCorePresentationWebCommon();
            services.AddDecisorCorePresentationWebBackend();
            services.AddDecisorLegalPresentationWebCommon();
            services.AddDecisorHumanResourcesPresentationWebCommon();
            services.AddDecisorHumanResourcesPresentationWebBackend();
            services.AddDecisorDomainPresentationWebCommon();
            services.AddDecisorFinancialPresentationWebCommon();
            services.AddDecisorServicingPresentationWebCommon();
            services.AddDecisorServicingPresentationWebBackend();

            services.AddScoped<IEntityRepository<Framework.Guama.Core.Persistence.ORM.EF.Entities.Trace, long>, Framework.Guama.Core.Persistence.ORM.EF.Repositories.TraceRepository>();

            services.AddAuthentication(config =>
            {
                config.DefaultScheme = Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie(config =>
            {
                config.AccessDeniedPath = new PathString("/error/403");
                config.LoginPath = new PathString("/security/account/login");
                config.ExpireTimeSpan = System.TimeSpan.FromMinutes(5);
                config.SlidingExpiration = true;
            });

            #region Security concreter dependencies configuration
            services.AddSingleton<Framework.Guama.Core.Presentation.Web.Security.Helpers.Facade.ILicenseValidationHelperFacade, Helpers.WillcardLicenseValidationHelper>();

            services.AddTransient<Framework.Guama.Core.Presentation.Web.Security.Models.View.Contrat.IUserProfileViewModel, Models.View.UserProfileViewModel>();

            services.AddSingleton<Framework.Guama.Core.Presentation.Web.Common.ModelBinding.Contract.IConcretModelBindHelper, Helpers.ConcretModelBindHelper>();

            services.AddScoped<Framework.Guama.Core.Presentation.Web.Security.Managers.Facade.IUserProfileManagerFacade, Managers.UserProfileManager>();
            #endregion

            services.Configure<Microsoft.AspNetCore.Routing.RouteOptions>(options => options.LowercaseUrls = true);

            services.AddLocalization();

            services.AddResponseCaching();
            services.AddMemoryCache();
            services.AddSession();

            services.AddMvc(mvc =>
            {
                mvc.EnableEndpointRouting = false;
                mvc.ModelBinderProviders.Insert(0, new Framework.Guama.Core.Presentation.Web.Common.ModelBinding.AbstractsModelBinderProvider());
            });

            services.AddDataProtection().PersistKeysToFileSystem(new System.IO.DirectoryInfo(System.IO.Path.Combine(env.ContentRootPath, "dpkeys")));

            services.AddSingleton<Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataProvider, Microsoft.AspNetCore.Mvc.ViewFeatures.CookieTempDataProvider>();
        }

        public void Configure(IApplicationBuilder app, Microsoft.Extensions.Options.IOptions<RequestLocalizationOptions> requestLocalizationOptions, Microsoft.Extensions.Logging.ILoggerFactory loggerFactory, DbContext dbContext, Framework.Guama.Core.Presentation.Web.Security.Managers.Facade.IRoleMemoryManagerFacade roleMemoryManager)
        {
            loggerFactory.AddSerilog(Log.Logger);

            app.UseRequestLocalization(requestLocalizationOptions.Value);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else if (env.IsStaging())
            {
                dbContext.Database.Migrate();

                var dataInitializationHelpers = app.ApplicationServices.GetServices<Framework.Guama.Core.Persistence.ORM.EF.Helpers.Facade.IDataInitializationHelper>();

                using (var serviceScope = app.ApplicationServices.CreateScope())
                {
                    var scopedDbContext = serviceScope.ServiceProvider.GetService<DbContext>();

                    foreach (var dataInitializationHelper in dataInitializationHelpers)
                    {
                        dataInitializationHelper.InitialiseData(scopedDbContext);
                    }
                }

                if (!((Persistence.ORM.EF.Context.ApplicationDbContext)dbContext).Set<Framework.Guama.Security.Personal.Persistence.Entities.User>().Any())
                {
                    var defaultUserId = "admin";

                    var k3y = new System.Guid(0x4c9294dd, 0x1e74, 0x45b2, 0xa8, 0x45, 0xaf, 0x6, 0xe5, 0x2a, 0xf6, 0x19);

                    var protectedPassword = (dbContext as Persistence.ORM.EF.Context.ApplicationDbContext).CreateSecureUser(k3y, defaultUserId, "system");

                    Log.Logger.Information(string.Format(">>>>>> Protected Password : \"{0}\" => \"{1}\"", defaultUserId, protectedPassword));
                }
            }
            else
            {
                app.UseExceptionHandler("/error/exception");

                app.UseHsts();
            }

            app.UseStatusCodePagesWithReExecute("/error/{0}");

            var atStartUpRoles = dbContext.Set<Framework.Guama.Core.Security.Common.Persistence.Entities.Role>().Include(e => e.PermissionBridges).ThenInclude(b => b.Stern).ToArray();

            foreach (var item in atStartUpRoles)
            {
                roleMemoryManager.RememberRole(item);
            }

            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute("defaultAreaRoutes",
                    template: "{area:exists}/{controller=start}/{action=index}/{id?}");

                routes.MapRoute(
                    name: "defaultRoutes",
                    template: "{controller=start}/{action=index}/{id?}");
            });
        }
    }
}
