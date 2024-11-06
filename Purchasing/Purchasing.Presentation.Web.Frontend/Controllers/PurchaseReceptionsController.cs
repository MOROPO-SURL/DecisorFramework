using Microsoft.Extensions.Logging;
using MOROPO.Framework.Decisor.Inventory.Persistence.Entities;
using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Purchasing.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Web.Frontend.Controllers.API
{
    [Microsoft.AspNetCore.Mvc.Route("api/purchasing/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class PurchaseReceptionsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEntityAPIManagementController<PurchaseReception, System.Guid, PurchaseReceptionInputModel, PurchaseReceptionDisplayModel>
    {
        private readonly IEntityRepository<Batch, System.Guid> batchRepository;

        public PurchaseReceptionsController(IEntityRepository<Batch, System.Guid> batchRepository, IEntityRepository<PurchaseReception, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<PurchaseReceptionsController> localizer, ILogger<PurchaseReceptionsController> logger) : base(repository, localizer, logger)
        {
            this.batchRepository = batchRepository;
        }

        public override Microsoft.AspNetCore.Mvc.ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        protected override void PreCreate(PurchaseReception entity, PurchaseReceptionInputModel model)
        {
            base.PreCreate(entity, model);

            foreach (var bridge in model.WeightBridges)
            {
                foreach (var _model in bridge.Batches)
                {
                    var _entity = _model.Export();

                    _entity.ProductId = bridge.Product.Id;
                    _entity.CostCenterId = bridge.CostCenter.Id;
                    _entity.ReceptionId = entity.Id;

                    var batch = batchRepository.Add(_entity, User.Identity.Name, false);

                    entity.BatchBridges.Add(new ReceptionBatchBridge { ProwId = entity.Id, SternId = batch.Id });
                }
            }
        }
    }
}
