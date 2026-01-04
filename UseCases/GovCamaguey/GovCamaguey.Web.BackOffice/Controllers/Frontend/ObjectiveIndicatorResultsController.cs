using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;
using MOROPO.GovCamaguey.Decisor.Prototype.Persistence.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Web.BackOffice.Controllers.Frontend;

[Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
[Route("api/governance/[controller]")]
[ApiController]
public class ObjectiveIndicatorResultsController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEntityAPIManagementController<ObjectiveIndicatorResult, long, Interop.API.Common.Models.Input.ObjectiveIndicatorResultInputModel, Interop.API.Common.Models.Display.ObjectiveIndicatorResultDisplayModel>
{
    public ObjectiveIndicatorResultsController(Framework.Guama.Core.Persistence.Repositories.IEntityRepository<ObjectiveIndicatorResult, long> repository, Microsoft.Extensions.Localization.IStringLocalizer<ObjectiveIndicatorResultsController> localizer, Microsoft.Extensions.Logging.ILogger<ObjectiveIndicatorResultsController> logger)
        : base(repository, localizer, logger)
    {
    }

    protected override System.Func<ObjectiveIndicatorResult, object> GetOrderSelector()
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

    [RequirePermissions(Interop.API.Common.Constants.Security.Authorization.ObjectiveIndicatorResultCreatorPermission)]
    public override ActionResult Create([FromBody] Interop.API.Common.Models.Input.ObjectiveIndicatorResultInputModel model)
    {
        return base.Create(model);
    }

    [RequirePermissions(Interop.API.Common.Constants.Security.Authorization.ObjectiveIndicatorResultEditorPermission)]
    public override ActionResult Edit([FromBody] Interop.API.Common.Models.Input.ObjectiveIndicatorResultInputModel model)
    {
        return base.Edit(model);
    }

    [HttpPost("lasts/by/indicators")]
    public ActionResult LastsByObjective([FromBody] System.Guid[] keys)
    {
        var rawResult = new List<ObjectiveIndicatorResult>();

        foreach (var key in keys)
        {
            var last = Repository.GetAll().Where(entity => entity.IndicatorId == key).OrderByDescending(entity => entity.At).FirstOrDefault();

            if (last == null) continue;

            rawResult.Add(last);
        }

        return Ok(rawResult.Select(entity => EntityToDisplayModel(entity)).ToArray());
    }
}
