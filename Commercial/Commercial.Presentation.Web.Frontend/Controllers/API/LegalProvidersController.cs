using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Decisor.Commercial.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Commercial.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Commercial.Persistence.Entities;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;
using MOROPO.Framework.Decisor.Financial.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Location.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Managers.Facade;
using System.Linq;

namespace MOROPO.Framework.Decisor.Commercial.Presentation.Web.Frontend.Controllers.API
{
    [Route("api/commercial/[controller]")]
    [ApiController]
    public class LegalProvidersController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEnableableEntityAPIManagementController<LegalProvider, System.Guid, LegalProviderInputModel, LegalProviderDisplayModel>
    {
        private readonly IEntityRepository<BankAccount, System.Guid> bankAccountRepository;
        private readonly IEntityRepository<Municipality, System.Guid> municipalityRepository;
        private readonly IEntityRepository<OrganizationContact, System.Guid> organizationContactRepository; 
        private readonly IEntityRepository<Document, System.Guid> documentRepository;
        private readonly IDocumentFileManagerFacade documentFileManager;

        public LegalProvidersController(IDocumentFileManagerFacade documentFileManager, IEntityRepository<Document, System.Guid> documentRepository, IEntityRepository<OrganizationContact, System.Guid> organizationContactRepository, IEntityRepository<Municipality, System.Guid> municipalityRepository, IEntityRepository<BankAccount, System.Guid> bankAccountRepository, IEntityRepository<LegalProvider, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<LegalProvidersController> localizer, Microsoft.Extensions.Logging.ILogger<LegalProvidersController> logger) : base(repository, localizer, logger)
        {
            this.bankAccountRepository = bankAccountRepository;
            this.municipalityRepository = municipalityRepository;
            this.organizationContactRepository = organizationContactRepository;
            this.documentRepository = documentRepository;
            this.documentFileManager = documentFileManager;
        }

        protected override System.Linq.Expressions.Expression<System.Func<LegalProvider, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<LegalProvider, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }

        public override ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        public override ActionResult Enable(System.Guid key)
        {
            return NotFound();
        }

        public override ActionResult Disable(System.Guid key)
        {
            return NotFound();
        }

        protected override LegalProviderDisplayModel EntityToDisplayModel(LegalProvider entity)
        {
            var model = base.EntityToDisplayModel(entity);

            model.Contact = new Domain.Interop.API.Common.Models.Display.OrganizationContactDisplayModel();
            
            model.Contact.Import(organizationContactRepository.Get(entity.ContactId));

            if (model.Contact.Identity.Image != null)
            {
                model.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Contact.Identity.Image.ContentType);
            }

            foreach (var _model in model.Contact.Identity.PostalContacts)
            {
                var municipality = municipalityRepository.Get(_model.Municipality.Id);

                _model.Municipality = new Core.Interop.API.Common.Models.Display.MunicipalityDisplayModel();

                _model.Municipality.Import(municipality);
            }

            if (model.Representative.Identity.Image != null)
            {
                model.Representative.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Representative.Identity.Image.ContentType);
            }

            model.MainPostalContact = model.Contact.Identity.PostalContacts.First(_model => _model.Id == entity.MainPostalContactId);

            model.Documents = entity.DocumentBridges.Select(bridge =>
            {
                var _model = new Core.Interop.API.Common.Models.Display.DocumentDisplayModel();

                _model.Import(bridge.Stern);

                _model.Extension = MimeTypes.MimeTypeMap.GetExtension(bridge.Stern.ContentType);

                return _model;
            }).ToArray();

            return model;
        }

        protected override void PreCreate(LegalProvider entity, LegalProviderInputModel model)
        {
            base.PreCreate(entity, model);

            foreach (var _model in model.IncomingBankAccounts)
            {
                var _entity = bankAccountRepository.Add(_model.Export(), User.Identity.Name, false);

                entity.BankAccountBridges.Add(new LegalProviderBankAccountBridge
                {
                    ProwId = entity.Id,
                    SternId = _entity.Id
                });
            }

            foreach (var _model in model.IncomingDocuments)
            {
                var _entity = documentRepository.Add(new Document
                {
                    Id = _model.Id,
                    Name = _model.Name,
                    ContentType = _model.ContentType,
                    Description = _model.Description,
                    Length = _model.ContentData.Length
                }, User.Identity.Name, false);

                entity.DocumentBridges.Add(new LegalProviderDocumentBridge
                {
                    ProwId = entity.Id,
                    SternId = _entity.Id
                });

                documentFileManager.SaveDocumentFileContent(_entity.Id, _model.ContentData, _entity.ContentType);
            }
        }

        protected override void PreEdit(LegalProvider entity, LegalProviderInputModel model)
        {
            base.PreEdit(entity, model);

            #region BankAccounts
            foreach (var _model in model.OutgoingBankAccounts)
            {
                var _entity = entity.BankAccountBridges.First(bridge => bridge.SternId == _model.Id).Stern;

                bankAccountRepository.Delete(_entity, User.Identity.Name, false);
            }

            foreach (var _model in model.EditionBankAccounts)
            {
                var _entity = entity.BankAccountBridges.First(bridge => bridge.SternId == _model.Id).Stern;

                _model.Mergue(_entity);

                bankAccountRepository.Update(_entity, User.Identity.Name, false);
            }

            foreach (var _model in model.IncomingBankAccounts)
            {
                var _entity = bankAccountRepository.Add(_model.Export(), User.Identity.Name, false);

                entity.BankAccountBridges.Add(new LegalProviderBankAccountBridge
                {
                    ProwId = entity.Id,
                    SternId = _entity.Id
                });
            }
            #endregion

            #region Documents
            foreach (var _model in model.OutgoingDocuments)
            {
                var _entity = entity.DocumentBridges.First(bridge => bridge.SternId == _model.Id).Stern;

                documentRepository.Delete(_entity, User.Identity.Name, false);
            }

            foreach (var _model in model.EditionDocuments)
            {
                var _entity = entity.DocumentBridges.First(bridge => bridge.SternId == _model.Id).Stern;

                _model.Mergue(_entity);

                documentRepository.Update(_entity, User.Identity.Name, false);
            }

            foreach (var _model in model.IncomingDocuments)
            {
                var _entity = documentRepository.Add(new Document
                {
                    Id = _model.Id,
                    Name = _model.Name,
                    ContentType = _model.ContentType,
                    Description = _model.Description,
                    Length = _model.ContentData.Length
                }, User.Identity.Name, false);

                entity.DocumentBridges.Add(new LegalProviderDocumentBridge
                {
                    ProwId = entity.Id,
                    SternId = _entity.Id
                });

                documentFileManager.SaveDocumentFileContent(_entity.Id, _model.ContentData, _entity.ContentType);
            }
            #endregion
        }

        protected override void PostEdit(LegalProvider entity, LegalProviderInputModel model)
        {
            base.PostEdit(entity, model);

            foreach (var _model in model.OutgoingDocuments)
            {
                documentFileManager.DeleteDocumentFile(new Document { Id = _model.Id, ContentType = MimeTypes.MimeTypeMap.GetMimeType(_model.Extension) });
            }
        }

        protected override void PreDelete(LegalProvider entity)
        {
            base.PreDelete(entity);

            foreach (var bridge in entity.BankAccountBridges)
            {
                bankAccountRepository.Delete(bridge.Stern, User.Identity.Name, false);
            }
        }

        protected override void PostDelete(LegalProvider entity)
        {
            base.PostDelete(entity);

            foreach (var bridge in entity.DocumentBridges)
            {
                documentRepository.Delete(bridge.Stern, User.Identity.Name, false);

                documentFileManager.DeleteDocumentFile(bridge.Stern);
            }
        }
    }
}
