using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Leasing.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Managers.Facade;
using System.Linq;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Web.Frontend.Controllers
{
    [Route("api/fwrk/leasing/[controller]")]
    [ApiController]
    public class VehicleLeasePersonPostulationsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEntityAPIManagementController<VehicleLeasePersonPostulation, System.Guid, VehicleLeasePersonPostulationInputModel, VehicleLeasePersonPostulationDisplayModel>
    {
        private readonly IEntityRepository<PersonContact, System.Guid> personContactRepository;
        private readonly IEntityRepository<Document, System.Guid> documentRepository;
        private readonly IDocumentFileManagerFacade documentFileManager;

        public VehicleLeasePersonPostulationsController(IDocumentFileManagerFacade documentFileManager, IEntityRepository<Document, System.Guid> documentRepository, IEntityRepository<PersonContact, System.Guid> personContactRepository, IEntityRepository<VehicleLeasePersonPostulation, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<VehicleLeasePersonPostulationsController> localizer, ILogger<VehicleLeasePersonPostulationsController> logger) : base(repository, localizer, logger)
        {
            this.personContactRepository = personContactRepository;
            this.documentRepository = documentRepository;
            this.documentFileManager = documentFileManager;
        }

        protected override System.Linq.Expressions.Expression<System.Func<VehicleLeasePersonPostulation, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived && !entity.Offer.Archived;
        }

        protected override void PreCreate(VehicleLeasePersonPostulation entity, VehicleLeasePersonPostulationInputModel model)
        {
            base.PreCreate(entity, model);

            var _entity = personContactRepository.Get(entity.ContactId);

            _entity.PersonalIdentificationNumber = model.TaxIdentificationNumber;
            _entity.BusinessKindId = model.BusinessKindId;
            _entity.MainPostalContactId = model.MainPostalContactItemId;

            personContactRepository.Update(_entity, User.Identity.Name, false);

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

                entity.DocumentBridges.Add(new VehicleLeasePersonPostulationDocumentBridge
                {
                    ProwId = entity.Id,
                    SternId = __entity.Id
                });

                documentFileManager.SaveDocumentFileContent(__entity.Id, _model.ContentData, __entity.ContentType);
            }
        }

        protected override void PreEdit(VehicleLeasePersonPostulation entity, VehicleLeasePersonPostulationInputModel model)
        {
            base.PreEdit(entity, model);

            entity.Contact.PersonalIdentificationNumber = model.TaxIdentificationNumber;

            if (entity.Contact.BusinessKindId != model.BusinessKindId)
            {
                entity.Contact.BusinessKind = null;
                entity.Contact.BusinessKindId = model.BusinessKindId;
            }

            if (model.MainPostalContactItemId != entity.Contact.MainPostalContactId)
            {
                entity.Contact.MainPostalContact = null;
                entity.Contact.MainPostalContactId = model.MainPostalContactItemId;
            }

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

                entity.DocumentBridges.Add(new VehicleLeasePersonPostulationDocumentBridge
                {
                    ProwId = entity.Id,
                    SternId = _entity.Id
                });

                documentFileManager.SaveDocumentFileContent(_entity.Id, _model.ContentData, _entity.ContentType);
            }
            #endregion
        }
    }
}