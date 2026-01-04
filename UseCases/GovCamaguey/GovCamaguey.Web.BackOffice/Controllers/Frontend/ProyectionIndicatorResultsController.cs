using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;
using MOROPO.GovCamaguey.Decisor.Prototype.Persistence.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Web.BackOffice.Controllers.Frontend;

[Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
[Route("api/governance/[controller]")]
[ApiController]
public class ProyectionIndicatorResultsController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEntityAPIManagementController<ProyectionIndicatorResult, long, Interop.API.Common.Models.Input.ProyectionIndicatorResultInputModel, Interop.API.Common.Models.Display.ProyectionIndicatorResultDisplayModel>
{
    public ProyectionIndicatorResultsController(Framework.Guama.Core.Persistence.Repositories.IEntityRepository<ProyectionIndicatorResult, long> repository, Microsoft.Extensions.Localization.IStringLocalizer<ProyectionIndicatorResultsController> localizer, Microsoft.Extensions.Logging.ILogger<ProyectionIndicatorResultsController> logger)
        : base(repository, localizer, logger)
    {
    }

    protected override System.Func<ProyectionIndicatorResult, object> GetOrderSelector()
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

    [RequirePermissions(Interop.API.Common.Constants.Security.Authorization.ProyectionIndicatorResultCreatorPermission)]
    public override ActionResult Create([FromBody] Interop.API.Common.Models.Input.ProyectionIndicatorResultInputModel model)
    {
        return base.Create(model);
    }

    [RequirePermissions(Interop.API.Common.Constants.Security.Authorization.ProyectionIndicatorResultEditorPermission)]
    public override ActionResult Edit([FromBody] Interop.API.Common.Models.Input.ProyectionIndicatorResultInputModel model)
    {
        return base.Edit(model);
    }

    [HttpPost("lasts/by/indicators")]
    public ActionResult LastsByObjective([FromBody] System.Guid[] keys)
    {
        var rawResult = new List<ProyectionIndicatorResult>();

        foreach (var key in keys)
        {
            var last = Repository.GetAll().Where(entity => entity.IndicatorId == key).OrderByDescending(entity => entity.At).FirstOrDefault();

            if (last == null) continue;

            rawResult.Add(last);
        }

        return Ok(rawResult.Select(entity => EntityToDisplayModel(entity)).ToArray());
    }
}
