using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Purchasing.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Web.Frontend.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/purchasing/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class PurchaseSpentsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementController<PurchaseSpent, System.Guid, PurchaseSpentInputModel, PurchaseSpentDisplayModel>
    {
        public PurchaseSpentsController(Guama.Core.Persistence.Repositories.IEntityRepository<PurchaseSpent, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<PurchaseSpentsController> localizer, Microsoft.Extensions.Logging.ILogger<PurchaseSpentsController> logger)
            : base(repository, localizer, logger)
        {
        }

        protected override System.Linq.Expressions.Expression<System.Func<PurchaseSpent, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived && entity.Enabled;
        }
    }
}
