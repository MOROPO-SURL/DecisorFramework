using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Filter;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Input;
using MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Web.Frontend.Controllers.API;

[Route("api/idi/[controller]")]
[ApiController]
public class ScientificTechnicalResultsController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementFilteredController<ScientificTechnicalResult, System.Guid, ScientificTechnicalResultInputModel, ScientificTechnicalResultDisplayModel, ScientificTechnicalResultFilterModel>
{
    public ScientificTechnicalResultsController(IEntityRepository<ScientificTechnicalResult, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<ScientificTechnicalResultsController> localizer, Microsoft.Extensions.Logging.ILogger<ScientificTechnicalResultsController> logger)
        : base(repository, localizer, logger)
    {
    }

    protected override System.Linq.Expressions.Expression<System.Func<ScientificTechnicalResult, bool>> GetGlobalSelector() => entity => !entity.Archived;

    protected override System.Func<ScientificTechnicalResult, object> GetOrderSelector() => entity => entity.At;

    protected override bool IsOrderDescending() => true;

    public override ActionResult Delete(System.Guid key)
    {
        return NotFound();
    }
}