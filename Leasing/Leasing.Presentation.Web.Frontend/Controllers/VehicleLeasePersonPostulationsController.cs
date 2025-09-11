using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Leasing.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Web.Frontend.Controllers
{
    [Route("api/leasing/[controller]")]
    [ApiController]
    public class VehicleLeasePersonPostulationsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEntityAPIManagementController<VehicleLeasePersonPostulation, System.Guid, VehicleLeasePersonPostulationInputModel, VehicleLeasePersonPostulationDisplayModel>
    {
        private readonly IEntityRepository<PersonContact, System.Guid> personContactRepository;

        public VehicleLeasePersonPostulationsController(IEntityRepository<PersonContact, System.Guid> personContactRepository, IEntityRepository<VehicleLeasePersonPostulation, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<VehicleLeasePersonPostulationsController> localizer, ILogger<VehicleLeasePersonPostulationsController> logger) : base(repository, localizer, logger)
        {
            this.personContactRepository = personContactRepository;
        }

        protected override void PreCreate(VehicleLeasePersonPostulation entity, VehicleLeasePersonPostulationInputModel model)
        {
            base.PreCreate(entity, model);

            var _entity = personContactRepository.Get(entity.ContactId);

            _entity.PersonalIdentificationNumber = model.TaxIdentificationNumber;
            _entity.BusinessKindId = model.BusinessKindId;
            _entity.MainPostalContactId = model.MainPostalContactItemId;

            personContactRepository.Update(_entity, User.Identity.Name, false);
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
        }
    }
}