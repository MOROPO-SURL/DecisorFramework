using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;
using MOROPO.GovCamaguey.Decisor.Prototype.Persistence.Entities;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Web.BackOffice.Controllers.Frontend;

public class GlobalIndicatorResultsController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEntityAPIManagementController<GlobalIndicatorResult, long, Interop.API.Common.Models.Input.GlobalIndicatorResultInputModel, Interop.API.Common.Models.Display.GlobalIndicatorResultDisplayModel>
{
    public GlobalIndicatorResultsController(Framework.Guama.Core.Persistence.Repositories.IEntityRepository<GlobalIndicatorResult, long> repository, Microsoft.Extensions.Localization.IStringLocalizer<GlobalIndicatorResultsController> localizer, Microsoft.Extensions.Logging.ILogger<GlobalIndicatorResultsController> logger)
        : base(repository, localizer, logger)
    {
    }

    protected override System.Func<GlobalIndicatorResult, object> GetOrderSelector()
    {
        return entity => entity.At;
    }

    protected override bool IsOrderDescending()
    {
        return true;
    }

    public override ActionResult Delete(long key)
    {
        return NotFound();
    }

    [RequirePermissions(Interop.API.Common.Constants.Security.Authorization.GlobalIndicatorResultCreatorPermission)]
    public override ActionResult Create([FromBody] Interop.API.Common.Models.Input.GlobalIndicatorResultInputModel model)
    {
        return base.Create(model);
    }

    [RequirePermissions(Interop.API.Common.Constants.Security.Authorization.GlobalIndicatorResultEditorPermission)]
    public override ActionResult Edit([FromBody] Interop.API.Common.Models.Input.GlobalIndicatorResultInputModel model)
    {
        return base.Edit(model);
    }
}
