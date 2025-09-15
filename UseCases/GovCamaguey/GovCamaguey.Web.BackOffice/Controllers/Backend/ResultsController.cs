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
    public class ResultsController : Framework.Guama.Core.Presentation.Web.Backend.Controllers.Contract.AbstractEntityManagementController<Result, long, ResultInputModel, ResultDisplayViewModel>
    {
        public ResultsController(Framework.Guama.Core.Persistence.Repositories.IEntityRepository<Result, long> repository, Microsoft.Extensions.Localization.IStringLocalizer<ResultsController> localizer, ILogger<ResultsController> logger) : base(repository, localizer, logger)
        {
        }

        [RequirePermissions(Interop.API.Common.Constants.Security.Authorization.ResultViewerPermission)]
        public override IActionResult Index(int sheet = 1, int limit = 25)
        {
            return base.Index(sheet, limit);
        }

        public override IActionResult Create()
        {
            return NotFound();
        }

        public override IActionResult Create(ResultInputModel model)
        {
            return NotFound();
        }

        public override IActionResult Edit(long key)
        {
            return NotFound();
        }

        public override IActionResult Edit(ResultInputModel model)
        {
            return NotFound();
        }

        public override IActionResult Delete(long key)
        {
            return NotFound();
        }

        [RequirePermissions(Interop.API.Common.Constants.Security.Authorization.ResultRemoverPermission)]
        public override IActionResult Delete(ResultDisplayViewModel model)
        {
            return base.Delete(model);
        }
    }
}
