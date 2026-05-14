using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Decisor.Commercial.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Commercial.Interop.API.Common.Models.Filter;
using MOROPO.Framework.Decisor.Commercial.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Commercial.Persistence.Entities;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;
using MOROPO.Framework.Decisor.Domain.Presentation.Web.Frontend.Extensions;
using MOROPO.Framework.Decisor.Financial.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Location.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Managers.Facade;
using System.Linq;

namespace MOROPO.Framework.Decisor.Commercial.Presentation.Web.Frontend.Controllers.API
{
    [Route("api/fwrk/commercial/[controller]")]
    [ApiController]
    public class NaturalClientsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEnableableEntityAPIManagementFilteredController<NaturalClient, System.Guid, NaturalClientInputModel, NaturalClientDisplayModel, NaturalClientFilterModel>
    {
        private readonly IEntityRepository<BankAccount, System.Guid> bankAccountRepository;
        private readonly IEntityRepository<Municipality, System.Guid> municipalityRepository;
        private readonly IEntityRepository<PersonContact, System.Guid> personContactRepository;
        private readonly IEntityRepository<Document, System.Guid> documentRepository;
        private readonly IDocumentFileManagerFacade documentFileManager;
        private readonly IEntityRepository<ChangeNotification, System.Guid> changeNotificationRepository;

        public NaturalClientsController(IEntityRepository<ChangeNotification, System.Guid> changeNotificationRepository, IDocumentFileManagerFacade documentFileManager, IEntityRepository<Document, System.Guid> documentRepository, IEntityRepository<PersonContact, System.Guid> personContactRepository, IEntityRepository<Municipality, System.Guid> municipalityRepository, IEntityRepository<BankAccount, System.Guid> bankAccountRepository, IEntityRepository<NaturalClient, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<NaturalClientsController> localizer, Microsoft.Extensions.Logging.ILogger<NaturalClientsController> logger) : base(repository, localizer, logger)
        {
            this.bankAccountRepository = bankAccountRepository;
            this.municipalityRepository = municipalityRepository;
            this.personContactRepository = personContactRepository;
            this.documentRepository = documentRepository;
            this.documentFileManager = documentFileManager;
            this.changeNotificationRepository = changeNotificationRepository;
        }

        protected override System.Linq.Expressions.Expression<System.Func<NaturalClient, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<NaturalClient, object> GetOrderSelector()
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

        protected override NaturalClientDisplayModel EntityToDisplayModel(NaturalClient entity)
        {
            var model = base.EntityToDisplayModel(entity);

            model.Contact = new Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel();

            model.Contact.Import(personContactRepository.Get(entity.ContactId));

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

            model.MainPostalContact = model.Contact.Identity.PostalContacts.First(_model => _model.Id == entity.Contact.MainPostalContactId);

            model.Documents = entity.DocumentBridges.Select(bridge =>
            {
                var _model = new Core.Interop.API.Common.Models.Display.DocumentDisplayModel();

                _model.Import(bridge.Stern);

                _model.Extension = MimeTypes.MimeTypeMap.GetExtension(bridge.Stern.ContentType);

                return _model;
            }).ToArray();

            return model;
        }

        protected override void PreCreate(NaturalClient entity, NaturalClientInputModel model)
        {
            base.PreCreate(entity, model);

            entity.ContactId = model.ContactId;

            var _entity = personContactRepository.Get(entity.ContactId);

            _entity.PersonalIdentificationNumber = model.PersonalIdentificationNumber;
            _entity.BusinessKindId = model.BusinessKindId;
            _entity.MainPostalContactId = model.MainPostalContactId;

            personContactRepository.Update(_entity, User.Identity.Name, false);

            foreach (var _model in model.IncomingBankAccounts)
            {
                var __entity = bankAccountRepository.Add(_model.Export(), User.Identity.Name, false);

                entity.BankAccountBridges.Add(new NaturalClientBankAccountBridge
                {
                    ProwId = entity.Id,
                    SternId = __entity.Id
                });
            }

            foreach (var _model in model.IncomingDocuments)
            {
                var __entity = documentRepository.Add(new Document
                {
                    Id = _model.Id,
                    Name = _model.Name,
                    ContentType = _model.ContentType,
                    Description = _model.Description,
                    Length = _model.ContentData.Length
                }, User.Identity.Name, false);

                entity.DocumentBridges.Add(new NaturalClientDocumentBridge
                {
                    ProwId = entity.Id,
                    SternId = __entity.Id
                });

                documentFileManager.SaveDocumentFileContent(__entity.Id, _model.ContentData, __entity.ContentType);
            }
        }

        protected override void PostCreate(NaturalClient entity, NaturalClientInputModel model)
        {
            base.PostCreate(entity, model);

            this.ChangeNotificationOnPostCreate(entity, model, changeNotificationRepository);
        }

        protected override void PreEdit(NaturalClient entity, NaturalClientInputModel model)
        {
            base.PreEdit(entity, model);

            if (model.ContactId != entity.ContactId)
            {
                entity.ContactId = model.ContactId;
                entity.Contact = personContactRepository.Get(entity.ContactId);
            }

            entity.Contact.PersonalIdentificationNumber = model.PersonalIdentificationNumber;

            if (entity.Contact.BusinessKindId != model.BusinessKindId)
            {
                entity.Contact.BusinessKind = null;
                entity.Contact.BusinessKindId = model.BusinessKindId;
            }

            if (model.MainPostalContactId != entity.Contact.MainPostalContactId)
            {
                entity.Contact.MainPostalContact = null;
                entity.Contact.MainPostalContactId = model.MainPostalContactId;
            }

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

                entity.BankAccountBridges.Add(new NaturalClientBankAccountBridge
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

                entity.DocumentBridges.Add(new NaturalClientDocumentBridge
                {
                    ProwId = entity.Id,
                    SternId = _entity.Id
                });

                documentFileManager.SaveDocumentFileContent(_entity.Id, _model.ContentData, _entity.ContentType);
            }
            #endregion
        }

        protected override void PostEdit(NaturalClient entity, NaturalClientInputModel model)
        {
            base.PostEdit(entity, model);

            this.ChangeNotificationOnPostEdit(entity, model, changeNotificationRepository);

            foreach (var _model in model.OutgoingDocuments)
            {
                documentFileManager.DeleteDocumentFile(new Document { Id = _model.Id, ContentType = MimeTypes.MimeTypeMap.GetMimeType(_model.Extension) });
            }
        }

        [HttpGet("by/contact/{key}")]
        public ActionResult GetByContact(System.Guid key)
        {
            var entity = Repository.FindOneBy(entity => entity.ContactId == key);

            return Ok(entity == null ? null : EntityToDisplayModel(entity));
        }
    }
}
