using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;
using MOROPO.ISCamaguey.Decisor.Production.Interop.API.Common.Constants.Security;
using MOROPO.ISCamaguey.Decisor.Production.Interop.API.Common.Models.Input;
using MOROPO.ISCamaguey.Decisor.Production.Persistence.Entities;
using MOROPO.ISCamaguey.Decisor.Production.Presentation.Web.Backend.Models.View.Display;

namespace MOROPO.ISCamaguey.Decisor.Production.Presentation.Web.Backend.Controllers;

[Microsoft.AspNetCore.Authorization.Authorize]
[RequirePermissions(Framework.Guama.Core.Security.Presentation.Constants.Permissions.ShellManager)]
[Area("production")]
public class ProductionQualityChecksController : Framework.Guama.Core.Presentation.Web.Backend.Controllers.Contract.AbstractArchivableEntityManagementController<ProductionQualityCheck, System.Guid, ProductionQualityCheckInputModel, ProductionQualityCheckDisplayViewModel>
{
    public ProductionQualityChecksController(IEntityRepository<ProductionQualityCheck, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<ProductionQualityChecksController> localizer, ILogger<ProductionQualityChecksController> logger) : base(repository, localizer, logger)
    {
    }

    [RequirePermissions(Authorization.ProductionQualityCheckViewerPermission)]
    public override IActionResult Index(int sheet = 1, int limit = 25)
    {
        return base.Index(sheet, limit);
    }

    public override IActionResult Create()
    {
        return NotFound();
    }

    public override IActionResult Create(ProductionQualityCheckInputModel model)
    {
        return NotFound();
    }

    public override IActionResult Edit(System.Guid key)
    {
        return NotFound();
    }

    public override IActionResult Edit(ProductionQualityCheckInputModel model)
    {
        return NotFound();
    }

    [RequirePermissions(Authorization.ProductionQualityCheckEditorPermission)]
    public override IActionResult Archive(System.Guid key)
    {
        return base.Archive(key);
    }

    [RequirePermissions(Authorization.ProductionQualityCheckEditorPermission)]
    public override IActionResult Unarchive(System.Guid key)
    {
        return base.Unarchive(key);
    }

    public override IActionResult Delete(System.Guid key)
    {
        return NotFound();
    }

    [RequirePermissions(Authorization.ProductionQualityCheckRemoverPermission)]
    public override IActionResult Delete(ProductionQualityCheckDisplayViewModel model)
    {
        return base.Delete(model);
    }
}
