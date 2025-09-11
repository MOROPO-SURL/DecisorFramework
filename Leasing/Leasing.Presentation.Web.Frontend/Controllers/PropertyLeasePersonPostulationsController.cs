using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Leasing.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using System.Linq;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Web.Frontend.Controllers
{
    [Route("api/leasing/[controller]")]
    [ApiController]
    public class PropertyLeasePersonPostulationsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEntityAPIManagementController<PropertyLeasePersonPostulation, System.Guid, PropertyLeasePersonPostulationInputModel, PropertyLeasePersonPostulationDisplayModel>
    {
        private readonly IEntityRepository<PersonContact, System.Guid> personContactRepository;

        public PropertyLeasePersonPostulationsController(IEntityRepository<PersonContact, System.Guid> personContactRepository, IEntityRepository<PropertyLeasePersonPostulation, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<PropertyLeasePersonPostulationsController> localizer, ILogger<PropertyLeasePersonPostulationsController> logger) : base(repository, localizer, logger)
        {
            this.personContactRepository = personContactRepository;
        }

        protected override void PreCreate(PropertyLeasePersonPostulation entity, PropertyLeasePersonPostulationInputModel model)
        {
            base.PreCreate(entity, model);

            var _entity = personContactRepository.Get(entity.ContactId);

            _entity.PersonalIdentificationNumber = model.TaxIdentificationNumber;
            _entity.BusinessKindId = model.BusinessKindId;
            _entity.MainPostalContactId = model.MainPostalContactItemId;

            personContactRepository.Update(_entity, User.Identity.Name, false);

            foreach (var _model in model.IncomingSpaces)
            {
                entity.PropertySpaceBridges.Add(new PropertyLeasePersonPostulationPropertySpaceLeasePropousalBridge { ProwId = entity.Id, SternId = _model.Id });
            }
        }

        protected override void PreEdit(PropertyLeasePersonPostulation entity, PropertyLeasePersonPostulationInputModel model)
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

            #region Spaces

            foreach (var _model in model.OutgoingSpaces)
            {
                var bridge = entity.PropertySpaceBridges.First(_bridge => _bridge.SternId == _model.Id);

                entity.PropertySpaceBridges.Remove(bridge);
            }

            foreach (var _model in model.IncomingSpaces)
            {
                entity.PropertySpaceBridges.Add(new PropertyLeasePersonPostulationPropertySpaceLeasePropousalBridge { ProwId = entity.Id, SternId = _model.Id });
            }

            #endregion
        }
    }
}