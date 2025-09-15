using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;
using MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Input;
using MOROPO.GovCamaguey.Decisor.Prototype.Persistence.Entities;
using MOROPO.GovCamaguey.Decisor.Prototype.Web.BackOffice.Models.View.Display;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Web.BackOffice.Controllers.Backend
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [RequirePermissions(Framework.Guama.Core.Security.Presentation.Constants.Permissions.ShellManager)]
    [Area("governance")]
    public class IndicatorsController : Framework.Guama.Core.Presentation.Web.Backend.Controllers.Contract.AbstractArchivableEnableableEntityManagementController<Indicator, System.Guid, IndicatorInputModel, IndicatorDisplayViewModel>
    {
        public IndicatorsController(Framework.Guama.Core.Persistence.Repositories.IEntityRepository<Indicator, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<IndicatorsController> localizer, ILogger<IndicatorsController> logger) : base(repository, localizer, logger)
        {
        }

        [RequirePermissions(Interop.API.Common.Constants.Security.Authorization.IndicatorViewerPermission)]
        public override IActionResult Index(int sheet = 1, int limit = 25)
        {
            return base.Index(sheet, limit);
        }

        public override IActionResult Create()
        {
            return NotFound();
        }

        public override IActionResult Create(IndicatorInputModel model)
        {
            return NotFound();
        }

        public override IActionResult Edit(System.Guid key)
        {
            return NotFound();
        }

        public override IActionResult Edit(IndicatorInputModel model)
        {
            return NotFound();
        }

        [RequirePermissions(Interop.API.Common.Constants.Security.Authorization.IndicatorEditorPermission)]
        public override IActionResult Enable(System.Guid key)
        {
            return base.Enable(key);
        }

        [RequirePermissions(Interop.API.Common.Constants.Security.Authorization.IndicatorEditorPermission)]
        public override IActionResult Disable(System.Guid key)
        {
            return base.Disable(key);
        }

        [RequirePermissions(Interop.API.Common.Constants.Security.Authorization.IndicatorEditorPermission)]
        public override IActionResult Archive(System.Guid key)
        {
            return base.Archive(key);
        }

        [RequirePermissions(Interop.API.Common.Constants.Security.Authorization.IndicatorEditorPermission)]
        public override IActionResult Unarchive(System.Guid key)
        {
            return base.Unarchive(key);
        }

        public override IActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        [RequirePermissions(Interop.API.Common.Constants.Security.Authorization.IndicatorRemoverPermission)]
        public override IActionResult Delete(IndicatorDisplayViewModel model)
        {
            return base.Delete(model);
        }
    }
}
