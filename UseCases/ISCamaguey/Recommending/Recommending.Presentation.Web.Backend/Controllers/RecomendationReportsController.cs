using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;
using MOROPO.ISCamaguey.Decisor.Recommending.Persistence.Entities;
using MOROPO.ISCamaguey.Decisor.Recommending.Interop.API.Common.Constants.Security;
using MOROPO.ISCamaguey.Decisor.Recommending.Interop.API.Common.Models.Input;
using Microsoft.Extensions.Logging;
using MOROPO.ISCamaguey.Decisor.Recommending.Presentation.Web.Backend.Models.View.Display;

namespace MOROPO.ISCamaguey.Decisor.Recommending.Presentation.Web.Backend.Controllers;

[Microsoft.AspNetCore.Authorization.Authorize]
[RequirePermissions(Framework.Guama.Core.Security.Presentation.Constants.Permissions.ShellManager)]
[Area("recommending")]
public sealed class RecomendationReportsController : Framework.Guama.Core.Presentation.Web.Backend.Controllers.Contract.AbstractArchivableEntityManagementController<RecomendationReport, System.Guid, RecomendationReportInputModel, RecomendationReportDisplayViewModel>
{
    public RecomendationReportsController(IEntityRepository<RecomendationReport, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<RecomendationReportsController> localizer, ILogger<RecomendationReportsController> logger) : base(repository, localizer, logger)
    {
    }

    [RequirePermissions(Authorization.RecomendationReportViewerPermission)]
    public override IActionResult Index(int sheet = 1, int limit = 25)
    {
        return base.Index(sheet, limit);
    }

    public override IActionResult Create()
    {
        return NotFound();
    }

    public override IActionResult Create(RecomendationReportInputModel model)
    {
        return NotFound();
    }

    public override IActionResult Edit(System.Guid key)
    {
        return NotFound();
    }

    public override IActionResult Edit(RecomendationReportInputModel model)
    {
        return NotFound();
    }

    [RequirePermissions(Authorization.RecomendationReportEditorPermission)]
    public override IActionResult Archive(System.Guid key)
    {
        return base.Archive(key);
    }

    [RequirePermissions(Authorization.RecomendationReportEditorPermission)]
    public override IActionResult Unarchive(System.Guid key)
    {
        return base.Unarchive(key);
    }

    public override IActionResult Delete(System.Guid key)
    {
        return NotFound();
    }

    [RequirePermissions(Authorization.RecomendationReportRemoverPermission)]
    public override IActionResult Delete(RecomendationReportDisplayViewModel model)
    {
        return base.Delete(model);
    }
}