using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Production.Persistence.Entities;
using MOROPO.Framework.Decisor.Production.Presentation.Web.Backend.Models.View.Display;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;

namespace MOROPO.Framework.Decisor.Production.Presentation.Web.Backend.Controllers;

[Microsoft.AspNetCore.Authorization.Authorize]
[RequirePermissions(Guama.Core.Security.Presentation.Constants.Permissions.ShellManager)]
[Area("production")]
public class ProductionOrdersController : Guama.Core.Presentation.Web.Backend.Controllers.Contract.AbstractArchivableEntityManagementController<ProductionOrder, System.Guid, ProductionOrderInputModel, ProductionPlanDisplayViewModel>
{
    public ProductionOrdersController(IEntityRepository<ProductionOrder, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<ProductionOrdersController> localizer, ILogger<ProductionOrdersController> logger) : base(repository, localizer, logger)
    {
    }

    [RequirePermissions(Interop.API.Common.Constants.Security.Authorization.ProductionPlanViewerPermission)]
    public override IActionResult Index(int sheet = 1, int limit = 25)
    {
        return base.Index(sheet, limit);
    }

    public override IActionResult Create()
    {
        return NotFound();
    }

    public override IActionResult Create(ProductionOrderInputModel model)
    {
        return NotFound();
    }

    public override IActionResult Edit(System.Guid key)
    {
        return NotFound();
    }

    public override IActionResult Edit(ProductionOrderInputModel model)
    {
        return NotFound();
    }

    [RequirePermissions(Interop.API.Common.Constants.Security.Authorization.ProductionPlanEditorPermission)]
    public override IActionResult Archive(System.Guid key)
    {
        return base.Archive(key);
    }

    [RequirePermissions(Interop.API.Common.Constants.Security.Authorization.ProductionPlanEditorPermission)]
    public override IActionResult Unarchive(System.Guid key)
    {
        return base.Unarchive(key);
    }

    public override IActionResult Delete(System.Guid key)
    {
        return NotFound();
    }

    [RequirePermissions(Interop.API.Common.Constants.Security.Authorization.ProductionPlanRemoverPermission)]
    public override IActionResult Delete(ProductionPlanDisplayViewModel model)
    {
        return base.Delete(model);
    }
}

