using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Filter;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Web.Frontend.Controllers.API
{
    [Microsoft.AspNetCore.Mvc.Route("api/fwrk/domain/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class LegalBusinessKindsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEntityAPIConsultFilteredController<LegalBusinessKind, System.Guid, LegalBusinessKindDisplayModel, LegalBusinessKindFilterModel>
    {
        public LegalBusinessKindsController(Guama.Core.Persistence.Repositories.IEntityRepository<LegalBusinessKind, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<LegalBusinessKindsController> localizer, Microsoft.Extensions.Logging.ILogger<LegalBusinessKindsController> logger)
            : base(repository, localizer, logger)
        {
        }

        protected override System.Linq.Expressions.Expression<System.Func<LegalBusinessKind, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<LegalBusinessKind, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }
    }
}
