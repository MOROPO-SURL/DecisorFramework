using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Production.Presentation.Web.Backend.Models.View.Display;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;

namespace MOROPO.Framework.Decisor.Production.Presentation.Web.Backend.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [RequirePermissions(Guama.Core.Security.Presentation.Constants.Permissions.ShellManager)]
    [Area("production")]
    public class ProductionsController : Guama.Core.Presentation.Web.Backend.Controllers.Contract.AbstractArchivableEnableableEntityManagementController<Persistence.Entities.Production, System.Guid, ProductionInputModel, ProductionDisplayViewModel>
    {
        public ProductionsController(IEntityRepository<Persistence.Entities.Production, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<ProductionsController> localizer, ILogger<ProductionsController> logger) : base(repository, localizer, logger)
        {
        }

        [RequirePermissions(Constants.Security.Authorization.ProductionViewerPermission)]
        public override IActionResult Index(int sheet = 1, int limit = 25)
        {
            return base.Index(sheet, limit);
        }

        public override IActionResult Create()
        {
            return NotFound();
        }

        public override IActionResult Create(ProductionInputModel model)
        {
            return NotFound();
        }

        public override IActionResult Edit(System.Guid key)
        {
            return NotFound();
        }

        public override IActionResult Edit(ProductionInputModel model)
        {
            return NotFound();
        }

        [RequirePermissions(Constants.Security.Authorization.ProductionEditorPermission)]
        public override IActionResult Enable(System.Guid key)
        {
            return base.Enable(key);
        }

        [RequirePermissions(Constants.Security.Authorization.ProductionEditorPermission)]
        public override IActionResult Disable(System.Guid key)
        {
            return base.Disable(key);
        }

        [RequirePermissions(Constants.Security.Authorization.ProductionEditorPermission)]
        public override IActionResult Archive(System.Guid key)
        {
            return base.Archive(key);
        }

        [RequirePermissions(Constants.Security.Authorization.ProductionEditorPermission)]
        public override IActionResult Unarchive(System.Guid key)
        {
            return base.Unarchive(key);
        }

        public override IActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        [RequirePermissions(Constants.Security.Authorization.ProductionRemoverPermission)]
        public override IActionResult Delete(ProductionDisplayViewModel model)
        {
            return base.Delete(model);
        }
    }
}

