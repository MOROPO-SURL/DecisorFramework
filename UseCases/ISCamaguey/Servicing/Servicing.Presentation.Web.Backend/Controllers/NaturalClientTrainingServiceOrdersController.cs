using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;
using MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Constants.Security;
using MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Input;
using MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities;
using MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Web.Backend.Models.View.Display;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Web.Backend.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [RequirePermissions(Framework.Guama.Core.Security.Presentation.Constants.Permissions.ShellManager)]
    [Area("Servicing")]
    public class NaturalClientTrainingServiceOrdersController : Framework.Guama.Core.Presentation.Web.Backend.Controllers.Contract.AbstractArchivableEnableableEntityManagementController<NaturalClientTrainingServiceOrder, long, NaturalClientTrainingServiceOrderInputModel, NaturalClientTrainingServiceOrderDisplayViewModel>
    {
        public NaturalClientTrainingServiceOrdersController(IEntityRepository<NaturalClientTrainingServiceOrder, long> repository, Microsoft.Extensions.Localization.IStringLocalizer<NaturalClientTrainingServiceOrdersController> localizer, ILogger<NaturalClientTrainingServiceOrdersController> logger) : base(repository, localizer, logger)
        {

        }

        [RequirePermissions(Authorization.NaturalClientTrainingServiceOrderViewerPermission)]
        public override IActionResult Index(int sheet = 1, int limit = 25)
        {
            return base.Index(sheet, limit);
        }

        public override IActionResult Create()
        {
            return NotFound();
        }

        public override IActionResult Create(NaturalClientTrainingServiceOrderInputModel model)
        {
            return NotFound();
        }

        public override IActionResult Edit(long key)
        {
            return NotFound();
        }

        public override IActionResult Edit(NaturalClientTrainingServiceOrderInputModel model)
        {
            return NotFound();
        }

        [RequirePermissions(Authorization.NaturalClientTrainingServiceOrderEditorPermission)]
        public override IActionResult Enable(long key)
        {
            return base.Enable(key);
        }

        [RequirePermissions(Authorization.NaturalClientTrainingServiceOrderEditorPermission)]
        public override IActionResult Disable(long key)
        {
            return base.Disable(key);
        }

        [RequirePermissions(Authorization.NaturalClientTrainingServiceOrderEditorPermission)]
        public override IActionResult Archive(long key)
        {
            return base.Archive(key);
        }

        [RequirePermissions(Authorization.NaturalClientTrainingServiceOrderEditorPermission)]
        public override IActionResult Unarchive(long key)
        {
            return base.Unarchive(key);
        }

        public override IActionResult Delete(long key)
        {
            return NotFound();
        }

        [RequirePermissions(Authorization.NaturalClientTrainingServiceOrderRemoverPermission)]
        public override IActionResult Delete(NaturalClientTrainingServiceOrderDisplayViewModel model)
        {
            return base.Delete(model);
        }
    }
}
