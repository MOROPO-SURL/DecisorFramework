using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Constants.Security;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Input;
using MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities;
using MOROPO.ISCamaguey.Decisor.IDi.Presentation.Web.Backend.Models.View.Display;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Web.Backend.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [RequirePermissions(Framework.Guama.Core.Security.Presentation.Constants.Permissions.ShellManager)]
    [Area("IDi")]
    public class ScientificTechnicalResultsController : Framework.Guama.Core.Presentation.Web.Backend.Controllers.Contract.AbstractArchivableEntityManagementController<ScientificTechnicalResult, System.Guid, ScientificTechnicalResultInputModel, ScientificTechnicalResultDisplayViewModel>
    {
        public ScientificTechnicalResultsController(IEntityRepository<ScientificTechnicalResult, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<ScientificTechnicalResultsController> localizer, ILogger<ScientificTechnicalResultsController> logger) : base(repository, localizer, logger)
        {
        }

        [RequirePermissions(Authorization.ScientificTechnicalResultViewerPermission)]
        public override IActionResult Index(int sheet = 1, int limit = 25)
        {
            return base.Index(sheet, limit);
        }

        public override IActionResult Create()
        {
            return NotFound();
        }

        public override IActionResult Create(ScientificTechnicalResultInputModel model)
        {
            return NotFound();
        }

        public override IActionResult Edit(System.Guid key)
        {
            return NotFound();
        }

        public override IActionResult Edit(ScientificTechnicalResultInputModel model)
        {
            return NotFound();
        }

        [RequirePermissions(Authorization.ScientificTechnicalResultEditorPermission)]
        public override IActionResult Archive(System.Guid key)
        {
            return base.Archive(key);
        }

        [RequirePermissions(Authorization.ScientificTechnicalResultEditorPermission)]
        public override IActionResult Unarchive(System.Guid key)
        {
            return base.Unarchive(key);
        }

        public override IActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        [RequirePermissions(Authorization.ScientificTechnicalResultRemoverPermission)]
        public override IActionResult Delete(ScientificTechnicalResultDisplayViewModel model)
        {
            return base.Delete(model);
        }
    }
}
