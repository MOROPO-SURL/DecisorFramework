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
    public class VehicleLeaseOrganizationPostulationsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEntityAPIManagementController<VehicleLeaseOrganizationPostulation, System.Guid, VehicleLeaseOrganizationPostulationInputModel, VehicleLeaseOrganizationPostulationDisplayModel>
    {
        private readonly IEntityRepository<OrganizationContact, System.Guid> organizationContactRepository;

        public VehicleLeaseOrganizationPostulationsController(IEntityRepository<OrganizationContact, System.Guid> organizationContactRepository, IEntityRepository<VehicleLeaseOrganizationPostulation, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<VehicleLeaseOrganizationPostulationsController> localizer, ILogger<VehicleLeaseOrganizationPostulationsController> logger) : base(repository, localizer, logger)
        {
            this.organizationContactRepository = organizationContactRepository;
        }

        protected override void PreCreate(VehicleLeaseOrganizationPostulation entity, VehicleLeaseOrganizationPostulationInputModel model)
        {
            base.PreCreate(entity, model);

            var _entity = organizationContactRepository.Get(entity.ContactId);

            _entity.TaxIdentificationNumber = model.TaxIdentificationNumber;
            _entity.StateIdentificationCode = model.StateIdentificationCode;
            _entity.MainPostalContactId = model.MainPostalContactItemId;

            organizationContactRepository.Update(_entity, User.Identity.Name, false);
        }

        protected override void PreEdit(VehicleLeaseOrganizationPostulation entity, VehicleLeaseOrganizationPostulationInputModel model)
        {
            base.PreEdit(entity, model);

            entity.Contact.TaxIdentificationNumber = model.TaxIdentificationNumber;
            entity.Contact.StateIdentificationCode = model.StateIdentificationCode;

            if (model.MainPostalContactItemId != entity.Contact.MainPostalContactId)
            {
                entity.Contact.MainPostalContact = null;
                entity.Contact.MainPostalContactId = model.MainPostalContactItemId;
            }
        }
    }
}