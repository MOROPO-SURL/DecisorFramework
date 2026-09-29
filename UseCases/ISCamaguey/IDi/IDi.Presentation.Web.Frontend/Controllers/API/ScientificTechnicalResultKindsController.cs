using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Filter;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Input;
using MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Web.Frontend.Controllers.API;

[Route("api/idi/[controller]")]
[ApiController]
public sealed class ScientificTechnicalResultKindsController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEnableableEntityAPIManagementFilteredController<ScientificTechnicalResultKind, System.Guid, ScientificTechnicalResultKindInputModel, ScientificTechnicalResultKindDisplayModel, ScientificTechnicalResultKindFilterModel>
{
    public ScientificTechnicalResultKindsController(IEntityRepository<ScientificTechnicalResultKind, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<ScientificTechnicalResultKindsController> localizer, Microsoft.Extensions.Logging.ILogger<ScientificTechnicalResultKindsController> logger) : base(repository, localizer, logger)
    {
    }

    protected override System.Linq.Expressions.Expression<System.Func<ScientificTechnicalResultKind, bool>> GetGlobalSelector()
    {
        return entity => !entity.Archived;
    }

    protected override System.Func<ScientificTechnicalResultKind, object> GetOrderSelector()
    {
        return entity => entity.Priority;
    }
}