using Microsoft.AspNetCore.Mvc;
using MOROPO.EPTCamaguey.Decisor.Web.BackOffice.Extensions;
using MOROPO.Framework.Guama.Core.Presentation.Web.Backend.Providers.Facade;

namespace MOROPO.EPTCamaguey.Decisor.Web.BackOffice.Components
{
    public class DashboardSidebarViewComponent : ViewComponent
    {
        private readonly System.Collections.Generic.IEnumerable<IManagementDashboardSectionProviderFacade> managementDashboardSectionProviders;

        public DashboardSidebarViewComponent(System.Collections.Generic.IEnumerable<IManagementDashboardSectionProviderFacade> managementDashboardSectionProviders)
        {
            this.managementDashboardSectionProviders = managementDashboardSectionProviders;
        }

        public IViewComponentResult Invoke()
        {
            return View(managementDashboardSectionProviders.ToManagementDashboardSectionGroups());
        }
    }
}
