using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Decisor.Purchasing.Persistence.Entities;
using MOROPO.Framework.Decisor.Purchasing.Presentation.Web.Backend.Models.View.Display;
using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Input;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Managers.Facade;
using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Constants.Security;
using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Display;
using System;
using Microsoft.Extensions.Localization;
using MOROPO.Framework.Guama.Core.Presentation.Web.Backend.Controllers.Contract;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Web.Backend.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [RequirePermissions(Guama.Core.Security.Presentation.Constants.Permissions.ShellManager)]
    [Area("purchasing")]
    public class PurchaseSpentsController : Guama.Core.Presentation.Web.Backend.Controllers.Contract.AbstractArchivableEntityManagementController<PurchaseSpent, System.Guid, PurchaseSpentInputModel, PurchaseSpentDisplayModel>
    {
        public PurchaseSpentsController(IEntityRepository<PurchaseSpent, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<PurchaseSpentsController> localizer, ILogger<PurchaseSpentsController> logger) : base(repository, localizer, logger)
        {
        }

        [RequirePermissions(Authorization.PurchaseSpentPermission)]
        public override IActionResult Index(int sheet = 1, int limit = 25)
        {
            return base.Index(sheet, limit);
        }

        public override IActionResult Create()
        {
            return NotFound();
        }

        public override IActionResult Create(PurchaseSpentInputModel model)
        {
            return NotFound();
        }

        public override IActionResult Edit(System.Guid key)
        {
            return NotFound();
        }

        public override IActionResult Edit(PurchaseSpentInputModel model)
        {
            return NotFound();

        }




        [RequirePermissions(Authorization.PurchaseSpentEditorPermission)]
        public override IActionResult Archive(System.Guid key)
        {
            return base.Archive(key);
        }

        [RequirePermissions(Authorization.PurchaseSpentEditorPermission)]
        public override IActionResult Unarchive(System.Guid key)
        {
            return base.Unarchive(key);
        }

        public override IActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        [RequirePermissions(Authorization.PurchaseSpentRemoverPermission)]
        public override IActionResult Delete(PurchaseSpentDisplayModel model)
        {
            return base.Delete(model);
        }
    }
}
