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
public sealed class FamiliesController : Guama.Core.Presentation.Web.Backend.Controllers.Contract.AbstractArchivableEntityManagementController<Family, int, FamilyInputModel, FamilyDisplayViewModel>
{
    public FamiliesController(IEntityRepository<Family, int> repository, Microsoft.Extensions.Localization.IStringLocalizer<FamiliesController> localizer, ILogger<FamiliesController> logger) : base(repository, localizer, logger)
    {
    }

    [RequirePermissions(Authorization.FamilyViewerPermission)]
    public override IActionResult Index(int sheet = 1, int limit = 25)
    {
        return base.Index(sheet, limit);
    }

    public override IActionResult Create()
    {
        return NotFound();
    }

    public override IActionResult Create(FamilyInputModel model)
    {
        return NotFound();
    }

    public override IActionResult Edit(int key)
    {
        return NotFound();
    }

    public override IActionResult Edit(FamilyInputModel model)
    {
        return NotFound();
    }

    [RequirePermissions(Authorization.FamilyEditorPermission)]
    public override IActionResult Archive(int key)
    {
        return base.Archive(key);
    }

    [RequirePermissions(Authorization.FamilyEditorPermission)]
    public override IActionResult Unarchive(int key)
    {
        return base.Unarchive(key);
    }

    public override IActionResult Delete(int key)
    {
        return NotFound();
    }

    [RequirePermissions(Authorization.FamilyRemoverPermission)]
    public override IActionResult Delete(FamilyDisplayViewModel model)
    {
        return base.Delete(model);
    }
}