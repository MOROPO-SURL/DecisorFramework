using Microsoft.Extensions.Logging;
using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Purchasing.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Web.Frontend.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/fwrk/purchasing/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class PurchaseOrdersController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementController<PurchaseOrder, System.Guid, PurchaseOrderInputModel, PurchaseOrderDisplayModel>
    {
        private readonly IEntityRepository<PurchaseRequest, System.Guid> requestRepository;
        private readonly IEntityRepository<LegalProviderBudget, System.Guid> legalProviderBudgetRepository;
        private readonly IEntityRepository<NaturalProviderBudget, System.Guid> naturalProviderBudgetRepository;
        private readonly IEntityRepository<PurchaseOrderExpectedProductResult, System.Guid> expectedProductResultRepository;
        private readonly IEntityRepository<PurchaseOrderPlannedProductSpent, System.Guid> plannedProductSpentRepository;

        public PurchaseOrdersController(IEntityRepository<PurchaseOrderPlannedProductSpent, System.Guid> plannedProductSpentRepository, IEntityRepository<PurchaseOrderExpectedProductResult, System.Guid> expectedProductResultRepository, IEntityRepository<NaturalProviderBudget, System.Guid> naturalProviderBudgetRepository, IEntityRepository<LegalProviderBudget, System.Guid> legalProviderBudgetRepository, IEntityRepository<PurchaseRequest, System.Guid> requestRepository, IEntityRepository<PurchaseOrder, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<PurchaseOrdersController> localizer, ILogger<PurchaseOrdersController> logger) : base(repository, localizer, logger)
        {
            this.requestRepository = requestRepository;
            this.legalProviderBudgetRepository = legalProviderBudgetRepository;
            this.naturalProviderBudgetRepository = naturalProviderBudgetRepository;
            this.expectedProductResultRepository = expectedProductResultRepository;
            this.plannedProductSpentRepository = plannedProductSpentRepository;
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

            foreach (var _entity in entity.ExpectedProductResults)
            {
                var _model = new PurchaseOrderExpectedProductResultDisplayModel();

                _model.Import(_entity);

                if (_model.Product.FeatureImage != null)
                {
                    _model.Product.FeatureImage.Extension = MimeTypes.MimeTypeMap.GetExtension(_entity.Product.FeatureImage.ContentType);
                }

                model.ExpectedProductResults.Add(_model);
            }

            foreach (var _entity in entity.PlannedProductSpents)
            {
                var _model = new PurchaseOrderPlannedProductSpentDisplayModel();

                _model.Import(_entity);

                if (_model.Product.FeatureImage != null)
                {
                    _model.Product.FeatureImage.Extension = MimeTypes.MimeTypeMap.GetExtension(_entity.Product.FeatureImage.ContentType);
                }

                model.PlannedProductSpents.Add(_model);
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

                foreach (var __entity in _entity.BudgetProducts)
                {
                    var __model = new LegalProviderBudgetProductDisplayModel();

                    __model.Import(__entity);

                    if (__model.Product.FeatureImage != null)
                    {
                        __model.Product.FeatureImage.Extension = MimeTypes.MimeTypeMap.GetExtension(__entity.Product.FeatureImage.ContentType);
                    }

                    _model.BudgetProducts.Add(__model);
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

                foreach (var __entity in _entity.BudgetProducts)
                {
                    var __model = new NaturalProviderBudgetProductDisplayModel();

                    __model.Import(__entity);

                    if (__model.Product.FeatureImage != null)
                    {
                        __model.Product.FeatureImage.Extension = MimeTypes.MimeTypeMap.GetExtension(__entity.Product.FeatureImage.ContentType);
                    }

                    _model.BudgetProducts.Add(__model);
                }

                model.NaturalProviderBudgets.Add(_model);
            }

            if (entity.Request != null)
            {
                foreach (var _entity in entity.Request.ExpectedProductAdquisitions)
                {
                    var _model = new PurchaseRequestExpectedProductAdquisitionDisplayModel();

                    _model.Import(_entity);

                    if (_model.Product.FeatureImage != null)
                    {
                        _model.Product.FeatureImage.Extension = MimeTypes.MimeTypeMap.GetExtension(_entity.Product.FeatureImage.ContentType);
                    }

                    model.Request.ExpectedProductAdquisitions.Add(_model);
                }
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

            foreach (var _model in model.IncomingExpectedProductResults)
            {
                var _entity = _model.Export();

                _entity.OrderId = entity.Id;

                expectedProductResultRepository.Add(_entity, User.Identity.Name, false);
            }

            foreach (var _model in model.IncomingPlannedProductSpents)
            {
                var _entity = _model.Export();

                _entity.OrderId = entity.Id;

                plannedProductSpentRepository.Add(_entity, User.Identity.Name, false);
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

            foreach (var _model in model.OutgoingExpectedProductResults)
            {
                var _entity = expectedProductResultRepository.Get(_model.Id);

                expectedProductResultRepository.Delete(_entity, User.Identity.Name, false);
            }

            foreach (var _model in model.EditionExpectedProductResults)
            {
                var _entity = expectedProductResultRepository.Get(_model.Id);

                _model.Mergue(_entity);

                expectedProductResultRepository.Update(_entity, User.Identity.Name, false);
            }

            foreach (var _model in model.IncomingExpectedProductResults)
            {
                var _entity = _model.Export();

                _entity.OrderId = entity.Id;

                expectedProductResultRepository.Add(_entity, User.Identity.Name, false);
            }

            foreach (var _model in model.OutgoingPlannedProductSpents)
            {
                var _entity = plannedProductSpentRepository.Get(_model.Id);

                plannedProductSpentRepository.Delete(_entity, User.Identity.Name, false);
            }

            foreach (var _model in model.EditionPlannedProductSpents)
            {
                var _entity = plannedProductSpentRepository.Get(_model.Id);

                _model.Mergue(_entity);

                plannedProductSpentRepository.Update(_entity, User.Identity.Name, false);
            }

            foreach (var _model in model.IncomingPlannedProductSpents)
            {
                var _entity = _model.Export();

                _entity.OrderId = entity.Id;

                plannedProductSpentRepository.Add(_entity, User.Identity.Name, false);
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
