using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Constants.Security;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;
using MOROPO.Framework.Decisor.Domain.Presentation.Web.Backend.Models.View.Display;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Web.Backend.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [RequirePermissions(Guama.Core.Security.Presentation.Constants.Permissions.ShellManager)]
    [Area("domain")]
    public class UnitMeasurementsController : Guama.Core.Presentation.Web.Backend.Controllers.Contract.AbstractArchivableEnableableEntityManagementController<UnitMeasurement, System.Guid, UnitMeasurementInputModel, UnitMeasurementDisplayViewModel>
    {
        public UnitMeasurementsController(IEntityRepository<UnitMeasurement, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<UnitMeasurementsController> localizer, ILogger<UnitMeasurementsController> logger) : base(repository, localizer, logger)
        {
        }

        [RequirePermissions(Authorization.UnitMeasurementViewerPermission)]
        public override IActionResult Index(int sheet = 1, int limit = 25)
        {
            return base.Index(sheet, limit);
        }

        public override IActionResult Create()
        {
            return NotFound();
        }

        public override IActionResult Create(UnitMeasurementInputModel model)
        {
            return NotFound();
        }

        public override IActionResult Edit(System.Guid key)
        {
            return NotFound();
        }

        public override IActionResult Edit(UnitMeasurementInputModel model)
        {
            return NotFound();
        }

        [RequirePermissions(Authorization.UnitMeasurementEditorPermission)]
        public override IActionResult Enable(System.Guid key)
        {
            return base.Enable(key);
        }

        [RequirePermissions(Authorization.UnitMeasurementEditorPermission)]
        public override IActionResult Disable(System.Guid key)
        {
            return base.Disable(key);
        }

        [RequirePermissions(Authorization.UnitMeasurementEditorPermission)]
        public override IActionResult Archive(System.Guid key)
        {
            return base.Archive(key);
        }

        [RequirePermissions(Authorization.UnitMeasurementEditorPermission)]
        public override IActionResult Unarchive(System.Guid key)
        {
            return base.Unarchive(key);
        }

        public override IActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        [RequirePermissions(Authorization.UnitMeasurementRemoverPermission)]
        public override IActionResult Delete(UnitMeasurementDisplayViewModel model)
        {
            return base.Delete(model);
        }
    }
}
