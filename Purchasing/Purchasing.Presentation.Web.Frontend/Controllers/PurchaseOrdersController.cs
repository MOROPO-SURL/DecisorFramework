using Microsoft.Extensions.Logging;
using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Bridge;
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
        private readonly IEntityRepository<LegalProviderBudget, System.Guid> legalProviderBudgetRepository;
        private readonly IEntityRepository<NaturalProviderBudget, System.Guid> naturalProviderBudgetRepository;

        public PurchaseOrdersController(IEntityRepository<NaturalProviderBudget, System.Guid> naturalProviderBudgetRepository, IEntityRepository<LegalProviderBudget, System.Guid> legalProviderBudgetRepository, IEntityRepository<PurchaseRequest, System.Guid> requestRepository, IEntityRepository<PurchaseOrder, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<PurchaseOrdersController> localizer, ILogger<PurchaseOrdersController> logger) : base(repository, localizer, logger)
        {
            this.requestRepository = requestRepository;
            this.legalProviderBudgetRepository = legalProviderBudgetRepository;
            this.naturalProviderBudgetRepository = naturalProviderBudgetRepository;
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

            foreach (var bridge in entity.ResultProductBridges)
            {
                var _model = new PurchaseCommonProductBridgeModel
                {
                    Product = new Inventory.Interop.API.Common.Models.Display.ProductDisplayModel(),
                    UnitMeasurement = new Domain.Interop.API.Common.Models.Display.UnitMeasurementDisplayModel(),
                    Amount = bridge.Amount
                };

                _model.Product.Import(bridge.Stern);
                _model.UnitMeasurement.Import(bridge.UnitMeasurement);

                if (bridge.Stern.FeatureImage != null)
                {
                    _model.Product.FeatureImage.Extension = MimeTypes.MimeTypeMap.GetExtension(bridge.Stern.FeatureImage.ContentType);
                }

                model.ResultProductBridges.Add(_model);
            }

            foreach (var bridge in entity.SpentProductBridges)
            {
                var _model = new PurchaseCommonProductBridgeModel
                {
                    Product = new Inventory.Interop.API.Common.Models.Display.ProductDisplayModel(),
                    UnitMeasurement = new Domain.Interop.API.Common.Models.Display.UnitMeasurementDisplayModel(),
                    Amount = bridge.Amount
                };

                _model.Product.Import(bridge.Stern);
                _model.UnitMeasurement.Import(bridge.UnitMeasurement);

                if (bridge.Stern.FeatureImage != null)
                {
                    _model.Product.FeatureImage.Extension = MimeTypes.MimeTypeMap.GetExtension(bridge.Stern.FeatureImage.ContentType);
                }

                model.SpentProductBridges.Add(_model);
            }

            foreach (var bridge in entity.LegalProviderBudgetBridges)
            {
                var _entity = legalProviderBudgetRepository.Get(bridge.SternId);

                var _model = new LegalProviderBudgetDisplayModel();

                _model.Import(_entity);

                if (_entity.Provider.Contact.Identity.Image != null)
                {
                    _model.Provider.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(_entity.Provider.Contact.Identity.Image.ContentType);
                }

                if (_entity.Commercial.Contact.Identity.Image != null)
                {
                    _model.Commercial.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(_entity.Commercial.Contact.Identity.Image.ContentType);
                }

                foreach (var _bridge in _entity.ProductBridges)
                {
                    var __model = new CommonBugetProductBridgeModel
                    {
                        Product = new Inventory.Interop.API.Common.Models.Display.ProductDisplayModel(),
                        Amount = _bridge.Amount,
                        UnitMeasurement = new Domain.Interop.API.Common.Models.Display.UnitMeasurementDisplayModel(),
                        UnitPrice = _bridge.UnitPrice,
                        Currency = new Financial.Interop.API.Common.Models.Display.CurrencyDisplayModel()
                    };

                    __model.Product.Import(_bridge.Stern);
                    __model.UnitMeasurement.Import(_bridge.UnitMeasurement);
                    __model.Currency.Import(_bridge.Currenty);

                    if (_bridge.Classification != null)
                    {
                        __model.Classification = new Inventory.Interop.API.Common.Models.Display.ClassificationDisplayModel();

                        __model.Classification.Import(_bridge.Classification);
                    }

                    if (__model.Product.FeatureImage != null)
                    {
                        __model.Product.FeatureImage.Extension = MimeTypes.MimeTypeMap.GetExtension(_bridge.Stern.FeatureImage.ContentType);
                    }

                    _model.ProductBridges.Add(__model);
                }

                model.LegalProviderBudgets.Add(_model);
            }

            foreach (var bridge in entity.NaturalProviderBudgetBridges)
            {
                var _entity = naturalProviderBudgetRepository.Get(bridge.SternId);

                var _model = new NaturalProviderBudgetDisplayModel();

                _model.Import(_entity);

                if (_entity.Provider.Contact.Identity.Image != null)
                {
                    _model.Provider.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(_entity.Provider.Contact.Identity.Image.ContentType);
                }

                if (_entity.Commercial.Contact.Identity.Image != null)
                {
                    _model.Commercial.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(_entity.Commercial.Contact.Identity.Image.ContentType);
                }

                foreach (var _bridge in _entity.ProductBridges)
                {
                    var __model = new CommonBugetProductBridgeModel
                    {
                        Product = new Inventory.Interop.API.Common.Models.Display.ProductDisplayModel(),
                        Amount = _bridge.Amount,
                        UnitMeasurement = new Domain.Interop.API.Common.Models.Display.UnitMeasurementDisplayModel(),
                        UnitPrice = _bridge.UnitPrice,
                        Currency = new Financial.Interop.API.Common.Models.Display.CurrencyDisplayModel()
                    };

                    __model.Product.Import(_bridge.Stern);
                    __model.UnitMeasurement.Import(_bridge.UnitMeasurement);
                    __model.Currency.Import(_bridge.Currenty);

                    if (_bridge.Classification != null)
                    {
                        __model.Classification = new Inventory.Interop.API.Common.Models.Display.ClassificationDisplayModel();

                        __model.Classification.Import(_bridge.Classification);
                    }

                    if (__model.Product.FeatureImage != null)
                    {
                        __model.Product.FeatureImage.Extension = MimeTypes.MimeTypeMap.GetExtension(_bridge.Stern.FeatureImage.ContentType);
                    }

                    _model.ProductBridges.Add(__model);
                }

                model.NaturalProviderBudgets.Add(_model);
            }

            return model;
        }

        protected override void PreCreate(PurchaseOrder entity, PurchaseOrderInputModel model)
        {
            base.PreCreate(entity, model);

            if (model.LegalProviderBudgets != null)
            {
                foreach (var item in model.LegalProviderBudgets)
                {
                    entity.LegalProviderBudgetBridges.Add(new PurchaseOrderLegalProviderBudgetBridge { ProwId = entity.Id, SternId = item.Id });
                }
            }

            if (model.NaturalProviderBudgets != null)
            {
                foreach (var item in model.NaturalProviderBudgets)
                {
                    entity.NaturalProviderBudgetBridges.Add(new PurchaseOrderNaturalProviderBudgetBridge { ProwId = entity.Id, SternId = item.Id });
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

            if (model.LegalProviderBudgets != null)
            {
                entity.LegalProviderBudgetBridges.Clear();

                foreach (var item in model.LegalProviderBudgets)
                {
                    entity.LegalProviderBudgetBridges.Add(new PurchaseOrderLegalProviderBudgetBridge { ProwId = entity.Id, SternId = item.Id });
                }
            }

            if (model.NaturalProviderBudgets != null)
            {
                entity.NaturalProviderBudgetBridges.Clear();

                foreach (var item in model.NaturalProviderBudgets)
                {
                    entity.NaturalProviderBudgetBridges.Add(new PurchaseOrderNaturalProviderBudgetBridge { ProwId = entity.Id, SternId = item.Id });
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
