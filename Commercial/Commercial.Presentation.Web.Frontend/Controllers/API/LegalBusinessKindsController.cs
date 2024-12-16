namespace MOROPO.Framework.Decisor.Commercial.Presentation.Web.Frontend.Controllers.API
{
    [Microsoft.AspNetCore.Mvc.Route("api/commercial/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class LegalBusinessKindsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEntityAPIConsultController<Persistence.Entities.LegalBusinessKind, System.Guid, Interop.API.Common.Models.Display.LegalBusinessKindDisplayModel>
    {
        public LegalBusinessKindsController(Guama.Core.Persistence.Repositories.IEntityRepository<Persistence.Entities.LegalBusinessKind, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<LegalBusinessKindsController> localizer, Microsoft.Extensions.Logging.ILogger<LegalBusinessKindsController> logger)
            : base(repository, localizer, logger)
        {

        }

        protected override System.Linq.Expressions.Expression<System.Func<Persistence.Entities.LegalBusinessKind, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived && entity.Enabled;
        }
    }
}
