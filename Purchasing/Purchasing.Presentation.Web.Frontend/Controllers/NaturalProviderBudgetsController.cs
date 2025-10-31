using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Bridge;
using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Filter;
using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Purchasing.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Managers.Facade;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Web.Frontend.Controllers
{
    [Route("api/fwrk/purchasing/[controller]")]
    [ApiController]
    public class NaturalProviderBudgetsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEnableableEntityAPIManagementFilteredController<NaturalProviderBudget, System.Guid, NaturalProviderBudgetInputModel, NaturalProviderBudgetDisplayModel, NaturalProviderBudgetFilterModel>
    {
        private readonly IEntityRepository<Document, System.Guid> documentRepository;
        private readonly IDocumentFileManagerFacade documentFileManager;

        public NaturalProviderBudgetsController(IDocumentFileManagerFacade documentFileManager, IEntityRepository<Document, System.Guid> documentRepository, IEntityRepository<NaturalProviderBudget, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<NaturalProviderBudgetsController> localizer, Microsoft.Extensions.Logging.ILogger<NaturalProviderBudgetsController> logger) : base(repository, localizer, logger)
        {
            this.documentRepository = documentRepository;
            this.documentFileManager = documentFileManager;
        }

        protected override System.Linq.Expressions.Expression<System.Func<NaturalProviderBudget, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<NaturalProviderBudget, object> GetOrderSelector()
        {
            return entity => entity.Year * 1000 + entity.Number;
        }

        protected override bool IsOrderDescending()
        {
            return true;
        }

        public override ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        protected override NaturalProviderBudgetDisplayModel EntityToDisplayModel(NaturalProviderBudget entity)
        {
            var model = base.EntityToDisplayModel(entity);

            if (entity.Provider.Contact.Identity.Image != null)
            {
                model.Provider.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Provider.Contact.Identity.Image.ContentType);
            }

            if (entity.Commercial.Contact.Identity.Image != null)
            {
                model.Commercial.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Commercial.Contact.Identity.Image.ContentType);
            }

            foreach (var bridge in entity.ProductBridges)
            {
                var _model = new CommonBugetProductBridgeModel
                {
                    Product = new Inventory.Interop.API.Common.Models.Display.ProductDisplayModel(),
                    Amount = bridge.Amount,
                    UnitMeasurement = new Domain.Interop.API.Common.Models.Display.UnitMeasurementDisplayModel(),
                    UnitPrice = bridge.UnitPrice,
                    Currency = new Financial.Interop.API.Common.Models.Display.CurrencyDisplayModel()
                };

                _model.Product.Import(bridge.Stern);
                _model.UnitMeasurement.Import(bridge.UnitMeasurement);
                _model.Currency.Import(bridge.Currenty);

                if (bridge.Classification != null)
                {
                    _model.Classification = new Inventory.Interop.API.Common.Models.Display.ClassificationDisplayModel();

                    _model.Classification.Import(bridge.Classification);
                }

                if (_model.Product.FeatureImage != null)
                {
                    _model.Product.FeatureImage.Extension = MimeTypes.MimeTypeMap.GetExtension(bridge.Stern.FeatureImage.ContentType);
                }

                model.ProductBridges.Add(_model);
            }

            if (model.Document != null)
            {
                model.Document.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Document.ContentType);
            }

            return model;
        }

        protected override void PreCreate(NaturalProviderBudget entity, NaturalProviderBudgetInputModel model)
        {
            base.PreCreate(entity, model);

            if (model.ProductBridges != null)
            {
                foreach (var item in model.ProductBridges)
                {
                    entity.ProductBridges.Add(new NaturalProviderBudgetProductBridge
                    {
                        ProwId = entity.Id,
                        SternId = item.Product.Id,
                        Amount = item.Amount,
                        UnitMeasurementId = item.UnitMeasurement.Id,
                        UnitPrice = item.UnitPrice,
                        CurrentyId = item.Currency.Id,
                        ClassificationId = item.Classification?.Id ?? null
                    });
                }
            }

            if (model.Document != null)
            {
                entity.Document = documentRepository.Add(new Document
                {
                    ContentType = model.Document.ContentType,
                    Length = model.Document.ContentData.LongLength,
                    Name = model.Document.Name,
                    Description = model.Document.Description
                }, User.Identity.Name, false);

                documentFileManager.SaveDocumentFileContent(entity.Document.Id, model.Document.ContentData, model.Document.ContentType);
            }
        }

        protected override void PreEdit(NaturalProviderBudget entity, NaturalProviderBudgetInputModel model)
        {
            base.PreEdit(entity, model);

            if (model.ProductBridges != null)
            {
                entity.ProductBridges.Clear();

                foreach (var item in model.ProductBridges)
                {
                    entity.ProductBridges.Add(new NaturalProviderBudgetProductBridge
                    {
                        ProwId = entity.Id,
                        SternId = item.Product.Id,
                        Amount = item.Amount,
                        UnitMeasurementId = item.UnitMeasurement.Id,
                        UnitPrice = item.UnitPrice,
                        CurrentyId = item.Currency.Id,
                        ClassificationId = item.Classification?.Id ?? null
                    });
                }
            }

            if (model.Document != null)
            {
                if (model.Document.ContentData == null)
                {
                    entity.Document.Name = model.Document.Name;
                    entity.Document.Description = model.Document.Description;

                    documentRepository.Update(entity.Document, User.Identity.Name, false);
                }
                else
                {
                    entity.Document = documentRepository.Add(new Document
                    {
                        ContentType = model.Document.ContentType,
                        Length = model.Document.ContentData.LongLength,
                        Name = model.Document.Name,
                        Description = model.Document.Description
                    }, User.Identity.Name, false);

                    documentFileManager.SaveDocumentFileContent(entity.Document.Id, model.Document.ContentData, model.Document.ContentType);
                }
            }
        }

        protected override void PostEdit(NaturalProviderBudget entity, NaturalProviderBudgetInputModel model)
        {
            base.PostEdit(entity, model);

            if (model.Document != null && model.Document.Id != default && model.Document.ContentData != null)
            {
                var oldRawDocument = documentRepository.Get(model.Document.Id);

                documentRepository.Delete(oldRawDocument, User.Identity.Name);

                documentFileManager.DeleteDocumentFile(oldRawDocument);
            }
        }
    }
}
