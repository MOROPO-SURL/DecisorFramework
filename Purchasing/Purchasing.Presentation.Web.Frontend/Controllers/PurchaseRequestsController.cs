using Microsoft.Extensions.Logging;
using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Purchasing.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using System.Linq;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Web.Frontend.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/fwrk/purchasing/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class PurchaseRequestsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementController<PurchaseRequest, System.Guid, PurchaseRequestInputModel, PurchaseRequestDisplayModel>
    {
        public PurchaseRequestsController(IEntityRepository<PurchaseRequest, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<PurchaseRequestsController> localizer, ILogger<PurchaseRequestsController> logger) : base(repository, localizer, logger)
        {
        }

        protected override System.Linq.Expressions.Expression<System.Func<PurchaseRequest, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<PurchaseRequest, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }

        public override Microsoft.AspNetCore.Mvc.ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        protected override PurchaseRequestDisplayModel EntityToDisplayModel(PurchaseRequest entity)
        {
            var model = base.EntityToDisplayModel(entity);

            if (entity.Author.Contact.Identity.Image != null)
            {
                model.Author.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Author.Contact.Identity.Image.ContentType);
            }

            foreach (var item in model.ProductBridges)
            {
                if (item.Product.FeatureImage != null)
                {
                    item.Product.FeatureImage.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.ProductBridges.First(bridge => bridge.SternId == item.Product.Id).Stern.FeatureImage.ContentType);
                }
            }

            return model;
        }

        protected override void PreCreate(PurchaseRequest entity, PurchaseRequestInputModel model)
        {
            base.PreCreate(entity, model);

            if (model.ProductBridges != null)
            {
                foreach (var item in model.ProductBridges)
                {
                    entity.ProductBridges.Add(new PurchaseRequestProductBridge { ProwId = entity.Id, SternId = item.Product.Id, UnitMeasurementId = item.UnitMeasurement.Id, Amount = item.Amount });
                }
            }
        }

        protected override void PreEdit(PurchaseRequest entity, PurchaseRequestInputModel model)
        {
            base.PreEdit(entity, model);

            if (model.ProductBridges != null)
            {
                entity.ProductBridges.Clear();

                foreach (var item in model.ProductBridges)
                {
                    entity.ProductBridges.Add(new PurchaseRequestProductBridge { ProwId = entity.Id, SternId = item.Product.Id, UnitMeasurementId = item.UnitMeasurement.Id, Amount = item.Amount });
                }
            }
        }
    }
}
