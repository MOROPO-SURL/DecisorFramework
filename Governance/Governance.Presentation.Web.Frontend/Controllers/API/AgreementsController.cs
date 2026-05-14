namespace MOROPO.Framework.Decisor.Governance.Presentation.Web.Frontend.Controllers.API;

[Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
[Microsoft.AspNetCore.Mvc.Route("api/fwrk/governance/[controller]")]
[Microsoft.AspNetCore.Mvc.ApiController]
public class AgreementsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEntityAPIConsultController<Persistence.Entities.Agreement, System.Guid, Interop.API.Common.Models.Display.AgreementDisplayModel>
{
    public AgreementsController(Guama.Core.Persistence.Repositories.IEntityRepository<Persistence.Entities.Agreement, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<AgreementsController> localizer, Microsoft.Extensions.Logging.ILogger<AgreementsController> logger) : base(repository, localizer, logger)
    {
    }

    protected override System.Linq.Expressions.Expression<System.Func<Persistence.Entities.Agreement, bool>> GetGlobalSelector()
    {
        return entity => !entity.Meeting.Archived;
    }
}
