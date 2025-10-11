using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Purchasing.Persistence.Entities;
using System.Linq;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Web.Frontend.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/fwrk/purchasing/[controller]")]
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

            foreach (var _model in model.IncomingSpentBridges)
            {
                entity.SpentBridges.Add(new PurchaseZoneSpentBridge
                {
                    ProwId = entity.Id,
                    SternId = _model.Spent.Id,
                    Amount = _model.Amount,
                    CurrencyId = _model.Currency.Id
                });
            }
        }

        protected override void PreEdit(PurchaseZone entity, PurchaseZoneInputModel model)
        {
            base.PreEdit(entity, model);

            foreach (var _model in model.OutgoingSpentBridges)
            {
                var bridge = entity.SpentBridges.First(bridge => bridge.SternId == _model.Spent.Id);

                entity.SpentBridges.Remove(bridge);
            }

            foreach (var _model in model.EditionSpentBridges)
            {
                var bridge = entity.SpentBridges.First(bridge => bridge.SternId == _model.Spent.Id);

                bridge.Amount = _model.Amount;
                bridge.CurrencyId = _model.Currency.Id;
            }

            foreach (var _model in model.IncomingSpentBridges)
            {
                entity.SpentBridges.Add(new PurchaseZoneSpentBridge
                {
                    ProwId = entity.Id,
                    SternId = _model.Spent.Id,
                    Amount = _model.Amount,
                    CurrencyId = _model.Currency.Id
                });
            }
        }
    }
}
