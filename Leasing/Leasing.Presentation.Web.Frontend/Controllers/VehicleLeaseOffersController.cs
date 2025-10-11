using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Leasing.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Location.Persistence.Entities;
using System.Linq;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Web.Frontend.Controllers
{
    [Route("api/fwrk/leasing/[controller]")]
    [ApiController]
    public class VehicleLeaseOffersController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEnableableEntityAPIManagementController<VehicleLeaseOffer, System.Guid, VehicleLeaseOfferInputModel, VehicleLeaseOfferDisplayModel>
    {
        private readonly IEntityRepository<VehicleLeasePropousal, System.Guid> propousalRepository;
        private readonly IEntityRepository<VehicleLeaseOrganizationPostulation, System.Guid> organizationPostulationRepository;
        private readonly IEntityRepository<VehicleLeasePersonPostulation, System.Guid> personPostulationRepository;
        private readonly IEntityRepository<Municipality, System.Guid> municipalityRepository;

        public VehicleLeaseOffersController(IEntityRepository<Municipality, System.Guid> municipalityRepository, IEntityRepository<VehicleLeasePersonPostulation, System.Guid> personPostulationRepository, IEntityRepository<VehicleLeaseOrganizationPostulation, System.Guid> organizationPostulationRepository, IEntityRepository<VehicleLeasePropousal, System.Guid> propousalRepository, IEntityRepository<VehicleLeaseOffer, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<VehicleLeaseOffersController> localizer, Microsoft.Extensions.Logging.ILogger<VehicleLeaseOffersController> logger) : base(repository, localizer, logger)
        {
            this.propousalRepository = propousalRepository;
            this.organizationPostulationRepository = organizationPostulationRepository;
            this.personPostulationRepository = personPostulationRepository;
            this.municipalityRepository = municipalityRepository;
        }

        protected override System.Linq.Expressions.Expression<System.Func<VehicleLeaseOffer, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived && entity.LeasedAt == null;
        }

        protected override System.Func<VehicleLeaseOffer, object> GetOrderSelector()
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

        protected override VehicleLeaseOfferDisplayModel EntityToDisplayModel(VehicleLeaseOffer entity)
        {
            var model = base.EntityToDisplayModel(entity);

            if (model.Propousal.Vehicle.FeatureImage != null)
            {
                model.Propousal.Vehicle.FeatureImage.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Propousal.Vehicle.FeatureImage.ContentType);
            }

            model.OrganizationPostulations = organizationPostulationRepository.FindBy(_entity => _entity.OfferId == entity.Id && !_entity.Archived).ToArray().Select(_entity =>
            {
                var _model = new VehicleLeaseOrganizationPostulationDisplayModel();

                _model.Import(_entity);

                if (_entity.Contact.Identity.Image != null)
                {
                    _model.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(_entity.Contact.Identity.Image.ContentType);
                }

                foreach (var __model in _model.Contact.Identity.PostalContacts)
                {
                    var municipality = municipalityRepository.Get(__model.Municipality.Id);

                    __model.Municipality = new Core.Interop.API.Common.Models.Display.MunicipalityDisplayModel();

                    __model.Municipality.Import(municipality);
                }

                _model.MainPostalContactItem = _model.Contact.Identity.PostalContacts.First(_model => _model.Id == _entity.Contact.MainPostalContactId);

                _model.Documents = _entity.DocumentBridges.Select(bridge =>
                {
                    var _model = new Core.Interop.API.Common.Models.Display.DocumentDisplayModel();

                    _model.Import(bridge.Stern);

                    _model.Extension = MimeTypes.MimeTypeMap.GetExtension(bridge.Stern.ContentType);

                    return _model;
                }).ToArray();

                return _model;
            }).ToArray();
            model.PersonPostulations = personPostulationRepository.FindBy(_entity => _entity.OfferId == entity.Id && !_entity.Archived).ToArray().Select(_entity =>
            {
                var _model = new VehicleLeasePersonPostulationDisplayModel();

                _model.Import(_entity);

                if (_entity.Contact.Identity.Image != null)
                {
                    _model.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(_entity.Contact.Identity.Image.ContentType);
                }

                foreach (var __model in _model.Contact.Identity.PostalContacts)
                {
                    var municipality = municipalityRepository.Get(__model.Municipality.Id);

                    __model.Municipality = new Core.Interop.API.Common.Models.Display.MunicipalityDisplayModel();

                    __model.Municipality.Import(municipality);
                }

                _model.MainPostalContactItem = _model.Contact.Identity.PostalContacts.First(_model => _model.Id == _entity.Contact.MainPostalContactId);

                _model.Documents = _entity.DocumentBridges.Select(bridge =>
                {
                    var _model = new Core.Interop.API.Common.Models.Display.DocumentDisplayModel();

                    _model.Import(bridge.Stern);

                    _model.Extension = MimeTypes.MimeTypeMap.GetExtension(bridge.Stern.ContentType);

                    return _model;
                }).ToArray();

                return _model;
            }).ToArray();

            return model;
        }

        protected override void PreCreate(VehicleLeaseOffer entity, VehicleLeaseOfferInputModel model)
        {
            base.PreCreate(entity, model);

            var propousal = propousalRepository.Get(model.PropousalId);
            
            propousal.Archived = true;

            propousalRepository.Update(propousal, User.Identity.Name, false);

            entity.PropousalId = model.PropousalId;
        }

        protected override void PreEdit(VehicleLeaseOffer entity, VehicleLeaseOfferInputModel model)
        {
            base.PreEdit(entity, model);

            if (entity.PropousalId != model.PropousalId)
            {
                var oldPropousal = propousalRepository.Get(entity.PropousalId);

                oldPropousal.Archived = false;

                propousalRepository.Update(oldPropousal, User.Identity.Name, false);

                entity.Propousal = null;
                entity.PropousalId = model.PropousalId;

                var newPropousal = propousalRepository.Get(model.PropousalId);

                newPropousal.Archived = true;

                propousalRepository.Update(newPropousal, User.Identity.Name, false);
            }
        }
    }
}
