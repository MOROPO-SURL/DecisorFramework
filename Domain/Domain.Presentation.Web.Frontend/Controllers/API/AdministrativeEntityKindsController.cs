namespace MOROPO.Framework.Decisor.Domain.Presentation.Web.Frontend.Controllers.API;

[Microsoft.AspNetCore.Mvc.Route("api/fwrk/domain/[controller]")]
[Microsoft.AspNetCore.Mvc.ApiController]
public class AdministrativeEntityKindsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEnableableEntityAPIConsultController<Persistence.Entities.AdministrativeEntityKind, System.Guid, Interop.API.Common.Models.Display.AdministrativeEntityKindDisplayModel>
{
    public AdministrativeEntityKindsController(Guama.Core.Persistence.Repositories.IEntityRepository<Persistence.Entities.AdministrativeEntityKind, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<AdministrativeEntityKindsController> localizer, Microsoft.Extensions.Logging.ILogger<AdministrativeEntityKindsController> logger)
        : base(repository, localizer, logger)
    {
    }

    protected override System.Linq.Expressions.Expression<System.Func<Persistence.Entities.AdministrativeEntityKind, bool>> GetGlobalSelector()
    {
        return entity => !entity.Archived && entity.Enabled;
    }

    protected override System.Func<Persistence.Entities.AdministrativeEntityKind, object> GetOrderSelector()
    {
        return entity => entity.Priority;
    }
}
