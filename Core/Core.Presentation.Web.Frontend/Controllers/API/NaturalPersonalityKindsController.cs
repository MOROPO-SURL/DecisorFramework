using MOROPO.Framework.Decisor.Core.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Core.Presentation.Web.Frontend.Controllers.API
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class NaturalBusinessKindsController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEntityAPIConsultController<NaturalBusinessKind, System.Guid, Core.Interop.API.Common.Models.Display.NaturalBusinessKindDisplayModel>
    {
        public NaturalBusinessKindsController(Framework.Guama.Core.Persistence.Repositories.IEntityRepository<NaturalBusinessKind, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<NaturalBusinessKindsController> localizer, Microsoft.Extensions.Logging.ILogger<NaturalBusinessKindsController> logger)
            : base(repository, localizer, logger)
        {
        }

        protected override System.Linq.Expressions.Expression<System.Func<NaturalBusinessKind, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived && entity.Enabled;
        }
    }
}