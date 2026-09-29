using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;
using MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Constants.Security;
using MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Input;
using MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities;
using MOROPO.ISCamaguey.Decisor.Lab.Presentation.Web.Backend.Models.View.Display;

namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Web.Backend.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [RequirePermissions(Framework.Guama.Core.Security.Presentation.Constants.Permissions.ShellManager)]
    [Area("Lab")]
    public class AssessmentQualityChecksController : Framework.Guama.Core.Presentation.Web.Backend.Controllers.Contract.AbstractArchivableEntityManagementController<AssessmentQualityCheck, System.Guid, AssessmentQualityCheckInputModel, AssessmentQualityCheckDisplayViewModel>
    {
        public AssessmentQualityChecksController(IEntityRepository<AssessmentQualityCheck, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<AssessmentQualityChecksController> localizer, ILogger<AssessmentQualityChecksController> logger) : base(repository, localizer, logger)
        {
        }

        [RequirePermissions(Authorization.AssessmentQualityCheckViewerPermission)]
        public override IActionResult Index(int sheet = 1, int limit = 25)
        {
            return base.Index(sheet, limit);
        }

        public override IActionResult Create()
        {
            return NotFound();
        }

        public override IActionResult Create(AssessmentQualityCheckInputModel model)
        {
            return NotFound();
        }

        public override IActionResult Edit(System.Guid key)
        {
            return NotFound();
        }

        public override IActionResult Edit(AssessmentQualityCheckInputModel model)
        {
            return NotFound();
        }

        [RequirePermissions(Authorization.AssessmentQualityCheckEditorPermission)]
        public override IActionResult Archive(System.Guid key)
        {
            return base.Archive(key);
        }

        [RequirePermissions(Authorization.AssessmentQualityCheckEditorPermission)]
        public override IActionResult Unarchive(System.Guid key)
        {
            return base.Unarchive(key);
        }

        public override IActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        [RequirePermissions(Authorization.AssessmentQualityCheckRemoverPermission)]
        public override IActionResult Delete(AssessmentQualityCheckDisplayViewModel model)
        {
            return base.Delete(model);
        }
    }
}
