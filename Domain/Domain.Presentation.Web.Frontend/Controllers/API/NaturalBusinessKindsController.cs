using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Web.Frontend.Controllers.API
{
    [Microsoft.AspNetCore.Mvc.Route("api/domain/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class NaturalBusinessKindsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEnableableEntityAPIConsultController<NaturalBusinessKind, System.Guid, NaturalBusinessKindDisplayModel>
    {
        public NaturalBusinessKindsController(Guama.Core.Persistence.Repositories.IEntityRepository<NaturalBusinessKind, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<NaturalBusinessKindsController> localizer, Microsoft.Extensions.Logging.ILogger<NaturalBusinessKindsController> logger)
            : base(repository, localizer, logger)
        {
        }

        protected override System.Linq.Expressions.Expression<System.Func<NaturalBusinessKind, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<NaturalBusinessKind, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }
    }
}