using Microsoft.AspNetCore.Mvc;
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
    public class LegalProviderBudgetsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEnableableEntityAPIManagementFilteredController<LegalProviderBudget, System.Guid, LegalProviderBudgetInputModel, LegalProviderBudgetDisplayModel, LegalProviderBudgetFilterModel>
    {
        private readonly IEntityRepository<LegalProviderBudgetProduct, System.Guid> budgetProductRepository;
        private readonly IEntityRepository<Document, System.Guid> documentRepository;
        private readonly IDocumentFileManagerFacade documentFileManager;

        public LegalProviderBudgetsController(IDocumentFileManagerFacade documentFileManager, IEntityRepository<Document, System.Guid> documentRepository, IEntityRepository<LegalProviderBudgetProduct, System.Guid> budgetProductRepository, IEntityRepository<LegalProviderBudget, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<LegalProviderBudgetsController> localizer, Microsoft.Extensions.Logging.ILogger<LegalProviderBudgetsController> logger) : base(repository, localizer, logger)
        {
            this.budgetProductRepository = budgetProductRepository;
            this.documentRepository = documentRepository;
            this.documentFileManager = documentFileManager;
        }

        protected override System.Linq.Expressions.Expression<System.Func<LegalProviderBudget, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<LegalProviderBudget, object> GetOrderSelector()
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

        protected override LegalProviderBudgetDisplayModel EntityToDisplayModel(LegalProviderBudget entity)
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

            foreach (var _entity in entity.BudgetProducts)
            {
                var _model = new LegalProviderBudgetProductDisplayModel();

                _model.Import(_entity);

                if (_model.Product.FeatureImage != null)
                {
                    _model.Product.FeatureImage.Extension = MimeTypes.MimeTypeMap.GetExtension(_entity.Product.FeatureImage.ContentType);
                }

                model.BudgetProducts.Add(_model);
            }

            if (model.Document != null)
            {
                model.Document.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Document.ContentType);
            }

            return model;
        }

        protected override void PreCreate(LegalProviderBudget entity, LegalProviderBudgetInputModel model)
        {
            base.PreCreate(entity, model);

            foreach (var _model in model.IncomingBudgetProducts)
            {
                var _entity = _model.Export();

                _entity.BudgetId = entity.Id;

                budgetProductRepository.Add(_entity, User.Identity.Name, false);
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

        protected override void PreEdit(LegalProviderBudget entity, LegalProviderBudgetInputModel model)
        {
            base.PreEdit(entity, model);

            foreach (var _model in model.OutgoingBudgetProducts)
            {
                var _entity = budgetProductRepository.Get(_model.Id);

                budgetProductRepository.Delete(_entity, User.Identity.Name, false);
            }

            foreach (var _model in model.EditionBudgetProducts)
            {
                var _entity = budgetProductRepository.Get(_model.Id);

                _model.Mergue(_entity);

                budgetProductRepository.Update(_entity, User.Identity.Name, false);
            }

            foreach (var _model in model.IncomingBudgetProducts)
            {
                var _entity = _model.Export();

                _entity.BudgetId = entity.Id;

                budgetProductRepository.Add(_entity, User.Identity.Name, false);
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

        protected override void PostEdit(LegalProviderBudget entity, LegalProviderBudgetInputModel model)
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
