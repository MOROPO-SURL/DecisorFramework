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
    public class PurchaseOrdersController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementController<PurchaseOrder, System.Guid, PurchaseOrderInputModel, PurchaseOrderDisplayModel>
    {
        private readonly IEntityRepository<PurchaseRequest, System.Guid> requestRepository;

        public PurchaseOrdersController(IEntityRepository<PurchaseRequest, System.Guid> requestRepository, IEntityRepository<PurchaseOrder, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<PurchaseOrdersController> localizer, ILogger<PurchaseOrdersController> logger) : base(repository, localizer, logger)
        {
            this.requestRepository = requestRepository;
        }

        protected override System.Linq.Expressions.Expression<System.Func<PurchaseOrder, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<PurchaseOrder, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }

        public override Microsoft.AspNetCore.Mvc.ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        protected override PurchaseOrderDisplayModel EntityToDisplayModel(PurchaseOrder entity)
        {
            var model = base.EntityToDisplayModel(entity);

            if (entity.Responsible.Contact.Identity.Image != null)
            {
                model.Responsible.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Responsible.Contact.Identity.Image.ContentType);
            }

            foreach (var item in model.ResultProductBridges)
            {
                if (item.Product.FeatureImage != null)
                {
                    item.Product.FeatureImage.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.ResultProductBridges.First(bridge => bridge.SternId == item.Product.Id).Stern.FeatureImage.ContentType);
                }
            }

            foreach (var item in model.SpentProductBridges)
            {
                if (item.Product.FeatureImage != null)
                {
                    item.Product.FeatureImage.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.SpentProductBridges.First(bridge => bridge.SternId == item.Product.Id).Stern.FeatureImage.ContentType);
                }
            }

            return model;
        }

        protected override void PreCreate(PurchaseOrder entity, PurchaseOrderInputModel model)
        {
            base.PreCreate(entity, model);

            if (model.LegalProviderBridges != null)
            {
                foreach (var item in model.LegalProviderBridges)
                {
                    entity.LegalProviderBridges.Add(new PurchaseOrderLegalProviderBridge { ProwId = entity.Id, SternId = item.Provider.Id, Debt = item.Debt });
                }
            }

            if (model.NaturalProviderBridges != null)
            {
                foreach (var item in model.NaturalProviderBridges)
                {
                    entity.NaturalProviderBridges.Add(new PurchaseOrderNaturalProviderBridge { ProwId = entity.Id, SternId = item.Provider.Id, Debt = item.Debt });
                }
            }

            if (model.ResultProductBridges != null)
            {
                foreach (var item in model.ResultProductBridges)
                {
                    entity.ResultProductBridges.Add(new PurchaseOrderProductResultBridge { ProwId = entity.Id, SternId = item.Product.Id, UnitMeasurementId = item.UnitMeasurement.Id, Amount = item.Amount });
                }
            }

            if (model.SpentProductBridges != null)
            {
                foreach (var item in model.SpentProductBridges)
                {
                    entity.SpentProductBridges.Add(new PurchaseOrderProductSpentBridge { ProwId = entity.Id, SternId = item.Product.Id, UnitMeasurementId = item.UnitMeasurement.Id, Amount = item.Amount });
                }
            }

            if (entity.RequestId != null)
            {
                var _entity = requestRepository.Get(entity.RequestId.Value);

                _entity.Archived = true;

                requestRepository.Update(_entity, User.Identity.Name, false);
            }
        }

        protected override void PreEdit(PurchaseOrder entity, PurchaseOrderInputModel model)
        {
            base.PreEdit(entity, model);

            if (model.LegalProviderBridges != null)
            {
                entity.LegalProviderBridges.Clear();

                foreach (var item in model.LegalProviderBridges)
                {
                    entity.LegalProviderBridges.Add(new PurchaseOrderLegalProviderBridge { ProwId = entity.Id, SternId = item.Provider.Id, Debt = item.Debt });
                }
            }

            if (model.NaturalProviderBridges != null)
            {
                entity.NaturalProviderBridges.Clear();

                foreach (var item in model.NaturalProviderBridges)
                {
                    entity.NaturalProviderBridges.Add(new PurchaseOrderNaturalProviderBridge { ProwId = entity.Id, SternId = item.Provider.Id, Debt = item.Debt });
                }
            }

            if (model.ResultProductBridges != null)
            {
                entity.ResultProductBridges.Clear();

                foreach (var item in model.ResultProductBridges)
                {
                    entity.ResultProductBridges.Add(new PurchaseOrderProductResultBridge { ProwId = entity.Id, SternId = item.Product.Id, UnitMeasurementId = item.UnitMeasurement.Id, Amount = item.Amount });
                }
            }

            if (model.SpentProductBridges != null)
            {
                entity.SpentProductBridges.Clear();

                foreach (var item in model.SpentProductBridges)
                {
                    entity.SpentProductBridges.Add(new PurchaseOrderProductSpentBridge { ProwId = entity.Id, SternId = item.Product.Id, UnitMeasurementId = item.UnitMeasurement.Id, Amount = item.Amount });
                }
            }

            if (entity.RequestId != model.RequestId)
            {
                if (entity.RequestId != null) 
                {
                    var _entity = requestRepository.Get(entity.RequestId.Value);

                    _entity.Archived = false;

                    requestRepository.Update(_entity, User.Identity.Name, false);
                }

                entity.Request = null;
                entity.RequestId = model.RequestId;

                if (entity.RequestId != null)
                {
                    var _entity = requestRepository.Get(entity.RequestId.Value);

                    _entity.Archived = true;

                    requestRepository.Update(_entity, User.Identity.Name, false);
                }
            }
        }
    }
}
