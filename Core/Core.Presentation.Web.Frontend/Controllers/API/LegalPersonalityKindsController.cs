using MOROPO.Framework.Decisor.Core.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Core.Presentation.Web.Frontend.Controllers.API
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class LegalPersonalityKindsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEntityAPIConsultController<LegalBusinessKind, System.Guid, Core.Interop.API.Common.Models.Display.LegalBusinessKindDisplayModel>
    {
        public LegalPersonalityKindsController(Guama.Core.Persistence.Repositories.IEntityRepository<LegalBusinessKind, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<LegalPersonalityKindsController> localizer, Microsoft.Extensions.Logging.ILogger<LegalPersonalityKindsController> logger)
            : base(repository, localizer, logger)
        {

        }

        protected override System.Linq.Expressions.Expression<System.Func<LegalBusinessKind, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived && entity.Enabled;
        }
    }
}
