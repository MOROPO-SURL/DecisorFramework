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

        protected override System.Func<PurchaseZone, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }

        public override Microsoft.AspNetCore.Mvc.ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        protected override void PreCreate(PurchaseZone entity, PurchaseZoneInputModel model)
        {
            base.PreCreate(entity, model);

            if (model.SpentBridges != null)
            {
                foreach (var item in model.SpentBridges)
                {
                    entity.SpentBridges.Add(new PurchaseZoneSpentBridge { ProwId = entity.Id, SternId = item.Spent.Id, Amount = item.Amount });
                }
            }
        }

        protected override void PreEdit(PurchaseZone entity, PurchaseZoneInputModel model)
        {
            base.PreEdit(entity, model);

            if (model.SpentBridges != null)
            {
                entity.SpentBridges.Clear();

                foreach (var item in model.SpentBridges)
                {
                    entity.SpentBridges.Add(new PurchaseZoneSpentBridge { ProwId = entity.Id, SternId = item.Spent.Id, Amount = item.Amount });
                }
            }
        }
    }
}
