using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Input;
using MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Web.Frontend.Controllers.API;

[Route("api/lab/[controller]")]
[ApiController]
public sealed class AnalysesController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementController<Analysis, System.Guid, AnalysisInputModel, AnalysisDisplayModel>
{
    public AnalysesController(IEntityRepository<Analysis, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<AnalysesController> localizer, Microsoft.Extensions.Logging.ILogger<AnalysesController> logger) : base(repository, localizer, logger)
    {
    }

    protected override System.Linq.Expressions.Expression<System.Func<Analysis, bool>> GetGlobalSelector()
    {
        return entity => !entity.Archived;
    }

    protected override System.Func<Analysis, object> GetOrderSelector()
    {
        return entity => entity.At;
    }

    public override ActionResult Delete(System.Guid key)
    {
        return NotFound();
    }

    protected override void PreCreate(Analysis entity, AnalysisInputModel model)
    {
        base.PreCreate(entity, model);

        entity.Sample.HandledAt = System.DateTime.Now;
    }
}
