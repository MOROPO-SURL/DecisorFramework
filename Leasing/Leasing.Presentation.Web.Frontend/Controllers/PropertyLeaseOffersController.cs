using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Leasing.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Location.Persistence.Entities;
using System.Linq;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Web.Frontend.Controllers
{
    [Route("api/leasing/[controller]")]
    [ApiController]
    public class PropertyLeaseOffersController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEnableableEntityAPIManagementController<PropertyLeaseOffer, System.Guid, PropertyLeaseOfferInputModel, PropertyLeaseOfferDisplayModel>
    {
        private readonly IEntityRepository<PropertyLeasePropousal, System.Guid> propousalRepository;
        private readonly IEntityRepository<PropertySpaceLeasePropousal, System.Guid> spaceLeasePropousalRepository;
        private readonly IEntityRepository<PropertyLeaseOrganizationPostulation, System.Guid> organizationPostulationRepository;
        private readonly IEntityRepository<PropertyLeasePersonPostulation, System.Guid> personPostulationRepository;
        private readonly IEntityRepository<Municipality, System.Guid> municipalityRepository;

        public PropertyLeaseOffersController(IEntityRepository<Municipality, System.Guid> municipalityRepository, IEntityRepository<PropertyLeasePersonPostulation, System.Guid> personPostulationRepository, IEntityRepository<PropertyLeaseOrganizationPostulation, System.Guid> organizationPostulationRepository, IEntityRepository<PropertySpaceLeasePropousal, System.Guid> spaceLeasePropousalRepository, IEntityRepository<PropertyLeasePropousal, System.Guid> propousalRepository, IEntityRepository<PropertyLeaseOffer, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<PropertyLeaseOffersController> localizer, Microsoft.Extensions.Logging.ILogger<PropertyLeaseOffersController> logger) : base(repository, localizer, logger)
        {
            this.propousalRepository = propousalRepository;
            this.spaceLeasePropousalRepository = spaceLeasePropousalRepository;
            this.organizationPostulationRepository = organizationPostulationRepository;
            this.personPostulationRepository = personPostulationRepository;
            this.municipalityRepository = municipalityRepository;
        }

        protected override System.Linq.Expressions.Expression<System.Func<PropertyLeaseOffer, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<PropertyLeaseOffer, object> GetOrderSelector()
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

        protected override PropertyLeaseOfferDisplayModel EntityToDisplayModel(PropertyLeaseOffer entity)
        {
            var model = base.EntityToDisplayModel(entity);

            if (model.Propousal.Property.FeatureImage != null)
            {
                model.Propousal.Property.FeatureImage.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Propousal.Property.FeatureImage.ContentType);
            }

            model.Propousal.SpacePropousals = spaceLeasePropousalRepository.FindBy(_entity => _entity.PropertyLeasePropousalId == entity.PropousalId).OrderBy(entity => entity.PropertySpace.Name).ToArray().Select(_entity =>
            {
                var _model = new PropertySpaceLeasePropousalDisplayModel();

                _model.Import(_entity);

                if (_entity.PropertySpace.FeatureImage != null)
                {
                    _model.Space.FeatureImage.Extension = MimeTypes.MimeTypeMap.GetExtension(_entity.PropertySpace.FeatureImage.ContentType);
                }

                return _model;
            }).ToArray();

            model.OrganizationPostulations = organizationPostulationRepository.FindBy(_entity => _entity.OfferId == entity.Id).ToArray().Select(_entity =>
            {
                var _model = new PropertyLeaseOrganizationPostulationDisplayModel();

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

                _model.Spaces = _entity.PropertySpaceBridges.Select(bridge =>
                {
                    var __model = new PropertySpaceLeasePropousalDisplayModel();

                    __model.Import(bridge.Stern);

                    if (bridge.Stern.PropertySpace.FeatureImage != null)
                    {
                        __model.Space.FeatureImage.Extension = MimeTypes.MimeTypeMap.GetExtension(bridge.Stern.PropertySpace.FeatureImage.ContentType);
                    }

                    return __model;
                }).ToArray();

                return _model;
            }).ToArray();
            model.PersonPostulations = personPostulationRepository.FindBy(_entity => _entity.OfferId == entity.Id).ToArray().Select(_entity =>
            {
                var _model = new PropertyLeasePersonPostulationDisplayModel();

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

                _model.Spaces = _entity.PropertySpaceBridges.Select(bridge =>
                {
                    var __model = new PropertySpaceLeasePropousalDisplayModel();

                    __model.Import(bridge.Stern);

                    if (bridge.Stern.PropertySpace.FeatureImage != null)
                    {
                        __model.Space.FeatureImage.Extension = MimeTypes.MimeTypeMap.GetExtension(bridge.Stern.PropertySpace.FeatureImage.ContentType);
                    }

                    return __model;
                }).ToArray();

                return _model;
            }).ToArray();

            return model;
        }

        protected override void PreCreate(PropertyLeaseOffer entity, PropertyLeaseOfferInputModel model)
        {
            base.PreCreate(entity, model);

            var propousal = propousalRepository.Get(model.PropousalId);
            
            propousal.Archived = true;

            propousalRepository.Update(propousal, User.Identity.Name, false);

            entity.PropousalId = model.PropousalId;
        }

        protected override void PreEdit(PropertyLeaseOffer entity, PropertyLeaseOfferInputModel model)
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
