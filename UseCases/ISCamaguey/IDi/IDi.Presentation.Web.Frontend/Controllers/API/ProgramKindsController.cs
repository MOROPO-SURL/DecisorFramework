using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Web.Frontend.Controllers.API;

[Route("api/idi/[controller]")]
[ApiController]
public class ProgramKindsController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEnableableEntityAPIConsultController<ProgramKind, System.Guid, ProgramKindDisplayModel>
{
    public ProgramKindsController(IEntityRepository<ProgramKind, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<ProgramKindsController> localizer, Microsoft.Extensions.Logging.ILogger<ProgramKindsController> logger) : base(repository, localizer, logger)
    {
    }

    protected override System.Linq.Expressions.Expression<System.Func<ProgramKind, bool>> GetGlobalSelector()
    {
        return entity => !entity.Archived;
    }

    protected override System.Func<ProgramKind, object> GetOrderSelector()
    {
        return entity => entity.Priority;
    }
}
