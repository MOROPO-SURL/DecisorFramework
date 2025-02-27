using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Decisor.Core.Presentation.Web.Frontend.Options;
using MOROPO.Framework.Decisor.Legal.Presentation.Web.Common.Extensions;
using MOROPO.Framework.Decisor.Financial.Presentation.Web.Common.Extensions;
using MOROPO.Framework.Decisor.Domain.Presentation.Web.Common.Extensions;
using MOROPO.Framework.Decisor.HumanResources.Presentation.Web.Common.Extensions;
using MOROPO.Framework.Decisor.Commercial.Presentation.Web.Common.Extensions;
using MOROPO.Framework.Decisor.Purchasing.Presentation.Web.Common.Extensions;
using MOROPO.Framework.Guama.Core.Security.Common.Presentation.Web.Frontend.Extensions;
using MOROPO.Framework.Guama.Location.Presentation.Web.Common.Extensions;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Extensions;
using MOROPO.Framework.Guama.Security.Personal.Presentation.Web.Backend.Extensions;
using Microsoft.AspNetCore.DataProtection;
using Serilog;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using System.Linq;
using MOROPO.Framework.Guama.Security.Personal.Persistence.ORM.EF.Extensions;
using System.Runtime.CompilerServices;
using System;
using Microsoft.AspNetCore.Http;
using MOROPO.EPTCamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Context;
using MOROPO.EPTCamaguey.Decisor.Web.BackOffice.Helpers;
using MOROPO.EPTCamaguey.Decisor.Web.BackOffice.Models.View;
using MOROPO.EPTCamaguey.Decisor.Web.BackOffice.Managers;
using MOROPO.Framework.Decisor.Inventory.Presentation.Web.Common.Extensions;

namespace MOROPO.EPTCamaguey.Decisor.Web.BackOffice
{
    public class Program
    {
        [ModuleInitializer]
        public static void Initialize()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
        }

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).CreateLogger();

            builder.Services.Configure<Framework.Guama.Media.Presentation.Web.Common.Options.RelativeMediaFileManagementOptions>(builder.Configuration.GetSection("FileManagement"));
            builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("JWT"));

            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<DbContext, ApplicationDbContext>();

            builder.Services.PerformCoreWebSecurityCommonFrontendServiceRegistration();
            builder.Services.PerformSecurityPersonalWebBackendServiceRegistration();
            builder.Services.PerformMediaWebCommonRelativePathFileManagementServiceRegistration();
            builder.Services.PerformLocationWebCommonServiceRegistration();

            builder.Services.AddDecisorLegalPresentationWebCommon();
            builder.Services.AddDecisorDomainPresentationWebCommon();
            builder.Services.AddDecisorHumanResourcesPresentationWebCommon();
            builder.Services.AddDecisorFinancialPresentationWebCommon();
            builder.Services.AddDecisorInventoryPresentationWebCommon();
            builder.Services.AddDecisorCommercialPresentationWebCommon();

            builder.Services.AddScoped<Framework.Guama.Core.Persistence.Repositories.IEntityRepository<Framework.Guama.Core.Persistence.ORM.EF.Entities.Trace, long>, Framework.Guama.Core.Persistence.ORM.EF.Repositories.TraceRepository>();

            builder.Services.AddAuthentication(config =>
            {
                config.DefaultScheme = Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie(config =>
            {
                config.AccessDeniedPath = new PathString("/error/403");
                config.LoginPath = new PathString("/security/account/login");
                config.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                config.SlidingExpiration = true;
            });

            #region Security concreter dependencies configuration
            builder.Services.AddSingleton<Framework.Guama.Core.Presentation.Web.Security.Helpers.Facade.ILicenseValidationHelperFacade, WillcardLicenseValidationHelper>();
            builder.Services.AddTransient<Framework.Guama.Core.Presentation.Web.Security.Models.View.Contrat.IUserProfileViewModel, UserProfileViewModel>();
            builder.Services.AddSingleton<Framework.Guama.Core.Presentation.Web.Common.ModelBinding.Contract.IConcretModelBindHelper, ConcretModelBindHelper>();
            builder.Services.AddScoped<Framework.Guama.Core.Presentation.Web.Security.Managers.Facade.IUserProfileManagerFacade, UserProfileManager>();
            #endregion

            builder.Services.Configure<Microsoft.AspNetCore.Routing.RouteOptions>(options => options.LowercaseUrls = true);

            builder.Services.AddLocalization();
            builder.Services.AddResponseCaching();
            builder.Services.AddMemoryCache();
            builder.Services.AddSession();

            builder.Services
                .AddControllersWithViews(config =>
                {
                    config.ModelBinderProviders.Insert(0, new Framework.Guama.Core.Presentation.Web.Common.ModelBinding.AbstractsModelBinderProvider());
                })
                .AddViewLocalization(Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization(config =>
                {
                    config.DataAnnotationLocalizerProvider = (type, factory) =>
                    {
                        return factory.Create(typeof(LocalizationResources));
                    };
                });

            builder.Services.AddCors();
            builder.Services.AddDataProtection().PersistKeysToFileSystem(new System.IO.DirectoryInfo(System.IO.Path.Combine(builder.Environment.ContentRootPath, "dpkeys")));
            builder.Services.AddSingleton<Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataProvider, Microsoft.AspNetCore.Mvc.ViewFeatures.CookieTempDataProvider>();

            var app = builder.Build();

            app.Services.GetService<Microsoft.Extensions.Logging.ILoggerFactory>().AddSerilog(Log.Logger);

            app.UseRequestLocalization(app.Services.GetService<Microsoft.Extensions.Options.IOptions<RequestLocalizationOptions>>().Value);

            using (var serviceScope = app.Services.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<DbContext>();

                if (app.Environment.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }
                else if (app.Environment.IsStaging())
                {
                    dbContext.Database.Migrate();

                    var dataInitializationHelpers = app.Services.GetServices<Framework.Guama.Core.Persistence.ORM.EF.Helpers.Facade.IDataInitializationHelper>();

                    foreach (var dataInitializationHelper in dataInitializationHelpers)
                    {
                        dataInitializationHelper.InitialiseData(dbContext);
                    }

                    if (!((ApplicationDbContext)dbContext).Users.Any())
                    {
                        var defaultUserId = "admin";
                        var k3y = new Guid(0x7c9294dd, 0x1e74, 0x45b2, 0xa8, 0x45, 0xaf, 0x6A, 0xe5, 0x2a, 0xf6, 0x19);

                        var protectedPassword = (dbContext as ApplicationDbContext).CreateSecureUser(k3y, defaultUserId, "system");

                        Log.Logger.Information(string.Format(">>>>>> Protected Password : '{0}' => '{1}'", defaultUserId, protectedPassword));
                    }
                }
                else
                {
                    app.UseExceptionHandler("/error/exception");
                    app.UseHsts();
                }
                app.UseStatusCodePagesWithReExecute("/error/{0}");

                var atStartUpRoles = dbContext.Set<Framework.Guama.Core.Security.Common.Persistence.Entities.Role>().Include(e => e.PermissionBridges).ThenInclude(b => b.Stern).ToArray();

                var roleMemoryManager = app.Services.GetService<Framework.Guama.Core.Presentation.Web.Security.Managers.Facade.IRoleMemoryManagerFacade>();

                foreach (var item in atStartUpRoles)
                {
                    roleMemoryManager.RememberRole(item);
                }
            }

            app
                .UseStaticFiles()
                .UseCors()
                .UseRouting()
                .UseAuthentication()
                .UseAuthorization()
                .UseSession()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute("area_default", "{area:exists}/{controller}/{action}/{id?}", new { action = "Index" });
                    endpoints.MapControllerRoute("default", "{controller}/{action}/{id?}", new { controller = "Start", action = "Index" });
                });

            app.Run();
        }
    }
}
