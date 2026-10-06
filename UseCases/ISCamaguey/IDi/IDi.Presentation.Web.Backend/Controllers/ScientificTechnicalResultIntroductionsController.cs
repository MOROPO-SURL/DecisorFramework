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
    public class ScientificTechnicalResultIntroductionsController : Framework.Guama.Core.Presentation.Web.Backend.Controllers.Contract.AbstractArchivableEntityManagementController<ScientificTechnicalResultIntroduction, System.Guid, ScientificTechnicalResultIntroductionInputModel, ScientificTechnicalResultIntroductionDisplayViewModel>
    {
        public ScientificTechnicalResultIntroductionsController(IEntityRepository<ScientificTechnicalResultIntroduction, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<ScientificTechnicalResultIntroductionsController> localizer, ILogger<ScientificTechnicalResultIntroductionsController> logger) : base(repository, localizer, logger)
        {
        }

        [RequirePermissions(Authorization.ScientificTechnicalResultIntroductionViewerPermission)]
        public override IActionResult Index(int sheet = 1, int limit = 25)
        {
            return base.Index(sheet, limit);
        }

        public override IActionResult Create()
        {
            return NotFound();
        }

        public override IActionResult Create(ScientificTechnicalResultIntroductionInputModel model)
        {
            return NotFound();
        }

        public override IActionResult Edit(System.Guid key)
        {
            return NotFound();
        }

        public override IActionResult Edit(ScientificTechnicalResultIntroductionInputModel model)
        {
            return NotFound();
        }

        [RequirePermissions(Authorization.ScientificTechnicalResultIntroductionEditorPermission)]
        public override IActionResult Archive(System.Guid key)
        {
            return base.Archive(key);
        }

        [RequirePermissions(Authorization.ScientificTechnicalResultIntroductionEditorPermission)]
        public override IActionResult Unarchive(System.Guid key)
        {
            return base.Unarchive(key);
        }

        public override IActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        [RequirePermissions(Authorization.ScientificTechnicalResultIntroductionRemoverPermission)]
        public override IActionResult Delete(ScientificTechnicalResultIntroductionDisplayViewModel model)
        {
            return base.Delete(model);
        }
    }
}
