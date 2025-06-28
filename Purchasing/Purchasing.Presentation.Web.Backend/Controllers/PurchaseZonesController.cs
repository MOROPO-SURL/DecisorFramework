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

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Web.Backend.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [RequirePermissions(Guama.Core.Security.Presentation.Constants.Permissions.ShellManager)]
    [Area("purchasing")]
    public class PurchaseZonesController: Guama.Core.Presentation.Web.Backend.Controllers.Contract.AbstractArchivableEntityManagementController<PurchaseZone, System.Guid, PurchaseZoneInputModel, PurchaseZoneDisplayModel>
    {
        public PurchaseZonesController(IEntityRepository<PurchaseZone, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<PurchaseZonesController> localizer, ILogger<PurchaseZonesController> logger) : base(repository, localizer, logger)
        {            
        }

        [RequirePermissions(Authorization.PurchaseZoneViewerPermission)]
        public override IActionResult Index(int sheet = 1, int limit = 25)
        {
            return base.Index(sheet, limit);
        }

        public override IActionResult Create()
        {
            return NotFound();
        }

        public override IActionResult Create(PurchaseZoneInputModel model)
        {
            return NotFound();
        }

        public override IActionResult Edit(System.Guid key)
        {
            return NotFound();
        }

        public override IActionResult Edit(PurchaseZoneInputModel model)
        {
            return NotFound();

        }




        [RequirePermissions(Authorization.PurchaseZoneEditorPermission)]
        public override IActionResult Archive(System.Guid key)
        {
            return base.Archive(key);
        }

        [RequirePermissions(Authorization.PurchaseZoneEditorPermission)]
        public override IActionResult Unarchive(System.Guid key)
        {
            return base.Unarchive(key);
        }

        public override IActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        [RequirePermissions(Authorization.PurchaseZoneRemoverPermission)]
        public override IActionResult Delete(PurchaseZoneDisplayModel model)
        {
            return base.Delete(model);
        }
    }
}
