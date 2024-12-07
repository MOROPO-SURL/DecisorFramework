using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Purchasing.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Web.Frontend.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/purchasing/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class PurchaseZonesController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementController<PurchaseZone, System.Guid, PurchaseZoneInputModel, PurchaseZoneDisplayModel>
    {
        public PurchaseZonesController(Guama.Core.Persistence.Repositories.IEntityRepository<PurchaseZone, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<PurchaseZonesController> localizer, Microsoft.Extensions.Logging.ILogger<PurchaseZonesController> logger)
            : base(repository, localizer, logger)
        {
        }

        protected override System.Linq.Expressions.Expression<System.Func<PurchaseZone, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived && entity.Enabled;
        }

        public override Microsoft.AspNetCore.Mvc.ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        [Microsoft.AspNetCore.Mvc.HttpGet("[action]")]
        public Microsoft.AspNetCore.Mvc.ActionResult<long> Count()
        {
            return Ok(Repository.Count());
        }
    }
}
