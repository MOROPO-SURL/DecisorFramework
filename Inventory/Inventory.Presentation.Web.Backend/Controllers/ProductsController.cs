using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Decisor.Inventory.Interop.API.Common.Constants.Security;
using MOROPO.Framework.Decisor.Inventory.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Inventory.Persistence.Entities;
using MOROPO.Framework.Decisor.Inventory.Presentation.Web.Backend.Models.View.Display;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;

namespace MOROPO.Framework.Decisor.Inventory.Presentation.Web.Backend.Controllers;

[Microsoft.AspNetCore.Authorization.Authorize]
[RequirePermissions(Guama.Core.Security.Presentation.Constants.Permissions.ShellManager)]
[Area("inventory")]
public sealed class ProductsController : Guama.Core.Presentation.Web.Backend.Controllers.Contract.AbstractArchivableEntityManagementController<Product, System.Guid, ProductInputModel, ProductDisplayViewModel>
{
    public ProductsController(IEntityRepository<Product, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<ProductsController> localizer, ILogger<ProductsController> logger) : base(repository, localizer, logger)
    {
    }

    [RequirePermissions(Authorization.ProductViewerPermission)]
    public override IActionResult Index(int sheet = 1, int limit = 25)
    {
        return base.Index(sheet, limit);
    }

    public override IActionResult Create()
    {
        return NotFound();
    }

    public override IActionResult Create(ProductInputModel model)
    {
        return NotFound();
    }

    public override IActionResult Edit(System.Guid key)
    {
        return NotFound();
    }

    public override IActionResult Edit(ProductInputModel model)
    {
        return NotFound();
    }

    [RequirePermissions(Authorization.ProductEditorPermission)]
    public override IActionResult Archive(System.Guid key)
    {
        return base.Archive(key);
    }

    [RequirePermissions(Authorization.ProductEditorPermission)]
    public override IActionResult Unarchive(System.Guid key)
    {
        return base.Unarchive(key);
    }

    public override IActionResult Delete(System.Guid key)
    {
        return NotFound();
    }

    [RequirePermissions(Authorization.ProductRemoverPermission)]
    public override IActionResult Delete(ProductDisplayViewModel model)
    {
        return base.Delete(model);
    }
}