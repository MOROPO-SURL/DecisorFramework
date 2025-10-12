using Microsoft.Extensions.Logging;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;
using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.HumanResources.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Location.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Managers.Facade;
using System.Linq;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Web.Frontend.Controllers.API
{
    [Microsoft.AspNetCore.Mvc.Route("api/fwrk/hhrr/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class VacantPostulationsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementController<VacantPostulation, System.Guid, VacantPostulationInputModel, VacantPostulationDisplayModel>
    {
        private readonly IEntityRepository<VacantPostulationOcupation, System.Guid> ocupationRepository;
        private readonly IEntityRepository<PersonContact, System.Guid> personContactRepository;
        private readonly IEntityRepository<Municipality, System.Guid> municipalityRepository;
        private readonly IEntityRepository<Document, System.Guid> documentRepository;
        private readonly IDocumentFileManagerFacade documentFileManager;

        public VacantPostulationsController(IDocumentFileManagerFacade documentFileManager, IEntityRepository<Document, System.Guid> documentRepository, IEntityRepository<Municipality, System.Guid> municipalityRepository, IEntityRepository<PersonContact, System.Guid> personContactRepository, IEntityRepository<VacantPostulationOcupation, System.Guid> ocupationRepository, IEntityRepository<VacantPostulation, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<VacantPostulationsController> localizer, ILogger<VacantPostulationsController> logger) : base(repository, localizer, logger)
        {
            this.ocupationRepository = ocupationRepository;
            this.personContactRepository = personContactRepository;
            this.municipalityRepository = municipalityRepository;
            this.documentRepository = documentRepository;
            this.documentFileManager = documentFileManager;
        }

        protected override System.Linq.Expressions.Expression<System.Func<VacantPostulation, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<VacantPostulation, object> GetOrderSelector()
        {
            return entity => entity.Vacant.Priority;
        }

        public override Microsoft.AspNetCore.Mvc.ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        protected override VacantPostulationDisplayModel EntityToDisplayModel(VacantPostulation entity)
        {
            var model = base.EntityToDisplayModel(entity);

            foreach (var _model in model.Contact.Identity.PostalContacts)
            {
                var municipality = municipalityRepository.Get(_model.Municipality.Id);

                _model.Municipality = new Core.Interop.API.Common.Models.Display.MunicipalityDisplayModel();

                _model.Municipality.Import(municipality);
            }

            var officialPostalContactItemMunicipality = municipalityRepository.Get((entity.OfficialPostalContactItem.Location as MunicipalityLocation).MunicipalityId.Value);

            model.OfficialPostalContactItem.Municipality = new Core.Interop.API.Common.Models.Display.MunicipalityDisplayModel();

            model.OfficialPostalContactItem.Municipality.Import(officialPostalContactItemMunicipality);

            if (model.AlternativePostalContactItem != null)
            {
                var altPostalContactItemMunicipality = municipalityRepository.Get((entity.AlternativePostalContactItem.Location as MunicipalityLocation).MunicipalityId.Value);

                model.AlternativePostalContactItem.Municipality = new Core.Interop.API.Common.Models.Display.MunicipalityDisplayModel();

                model.AlternativePostalContactItem.Municipality.Import(altPostalContactItemMunicipality);
            }

            if (entity.Contact.Identity.Image != null)
            {
                model.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Contact.Identity.Image.ContentType);
            }

            model.Ocupations = ocupationRepository.FindBy(_entity => _entity.PostulationId == entity.Id).OrderBy(entity => entity.StartAt).ToArray().Select(_entity =>
            {
                var _model = new VacantPostulationOcupationDisplayModel();

                _model.Import(_entity);

                return _model;
            }).ToArray();

            model.Documents = entity.DocumentBridges.Select(bridge =>
            {
                var _model = new Core.Interop.API.Common.Models.Display.DocumentDisplayModel();

                _model.Import(bridge.Stern);

                _model.Extension = MimeTypes.MimeTypeMap.GetExtension(bridge.Stern.ContentType);

                return _model;
            }).ToArray();

            return model;
        }

        protected override void PreCreate(VacantPostulation entity, VacantPostulationInputModel model)
        {
            base.PreCreate(entity, model);

            foreach (var _model in model.IncomingOcupations)
            {
                var _entity = _model.Export();

                _entity.PostulationId = entity.Id;

                ocupationRepository.Add(_entity, User.Identity.Name, false);
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

                entity.DocumentBridges.Add(new VacantPostulationDocumentBridge
                {
                    ProwId = entity.Id,
                    SternId = __entity.Id
                });

                documentFileManager.SaveDocumentFileContent(__entity.Id, _model.ContentData, __entity.ContentType);
            }
        }

        protected override void PostCreate(VacantPostulation entity, VacantPostulationInputModel model)
        {
            base.PostCreate(entity, model);

            if (model.PersonalIdentificationNumber != null)
            {
                var _entity = personContactRepository.Get(entity.ContactId);
                
                _entity.PersonalIdentificationNumber = model.PersonalIdentificationNumber;

                personContactRepository.Update(_entity, User.Identity.Name);
            }
        }

        protected override void PreEdit(VacantPostulation entity, VacantPostulationInputModel model)
        {
            base.PreEdit(entity, model);

            #region Ocupations

            foreach (var _model in model.OutgoingOcupations)
            {
                ocupationRepository.Delete(new VacantPostulationOcupation { Id = _model.Id }, User.Identity.Name, false);
            }

            foreach (var _model in model.EditionOcupations)
            {
                var _entity = ocupationRepository.Get(_model.Id);

                _model.Mergue(_entity);

                ocupationRepository.Update(_entity, User.Identity.Name, false);
            }

            foreach (var _model in model.IncomingOcupations)
            {
                var _entity = _model.Export();

                _entity.PostulationId = entity.Id;

                ocupationRepository.Add(_entity, User.Identity.Name, false);
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

                entity.DocumentBridges.Add(new VacantPostulationDocumentBridge
                {
                    ProwId = entity.Id,
                    SternId = _entity.Id
                });

                documentFileManager.SaveDocumentFileContent(_entity.Id, _model.ContentData, _entity.ContentType);
            }
            #endregion
        }

        protected override void PostEdit(VacantPostulation entity, VacantPostulationInputModel model)
        {
            base.PostEdit(entity, model);

            if (model.PersonalIdentificationNumber != null)
            {
                entity.Contact.PersonalIdentificationNumber = model.PersonalIdentificationNumber;

                personContactRepository.Update(entity.Contact, User.Identity.Name);
            }
        }
    }
}
