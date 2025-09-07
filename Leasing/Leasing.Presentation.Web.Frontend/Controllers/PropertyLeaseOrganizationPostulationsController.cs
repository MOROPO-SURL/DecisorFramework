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
    public class PropertyLeaseOrganizationPostulationsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEntityAPIManagementController<PropertyLeaseOrganizationPostulation, System.Guid, PropertyLeaseOrganizationPostulationInputModel, PropertyLeaseOrganizationPostulationDisplayModel>
    {
        private readonly IEntityRepository<OrganizationContact, System.Guid> organizationContactRepository;

        public PropertyLeaseOrganizationPostulationsController(IEntityRepository<OrganizationContact, System.Guid> organizationContactRepository, IEntityRepository<PropertyLeaseOrganizationPostulation, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<PropertyLeaseOrganizationPostulationsController> localizer, ILogger<PropertyLeaseOrganizationPostulationsController> logger) : base(repository, localizer, logger)
        {
            this.organizationContactRepository = organizationContactRepository;
        }

        protected override void PreCreate(PropertyLeaseOrganizationPostulation entity, PropertyLeaseOrganizationPostulationInputModel model)
        {
            base.PreCreate(entity, model);

            var _entity = organizationContactRepository.Get(entity.ContactId);

            _entity.TaxIdentificationNumber = model.TaxIdentificationNumber;
            _entity.StateIdentificationCode = model.StateIdentificationCode;
            _entity.MainPostalContactId = model.MainPostalContactItemId;

            organizationContactRepository.Update(_entity, User.Identity.Name, false);

            foreach (var _model in model.IncomingSpaces)
            {
                entity.PropertySpaceBridges.Add(new PropertyLeaseOrganizationPostulationPropertySpaceLeasePropousalBridge { ProwId = entity.Id, SternId = _model.Id });
            }
        }

        protected override void PreEdit(PropertyLeaseOrganizationPostulation entity, PropertyLeaseOrganizationPostulationInputModel model)
        {
            base.PreEdit(entity, model);

            entity.Contact.TaxIdentificationNumber = model.TaxIdentificationNumber;
            entity.Contact.StateIdentificationCode = model.StateIdentificationCode;

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
                entity.PropertySpaceBridges.Add(new PropertyLeaseOrganizationPostulationPropertySpaceLeasePropousalBridge { ProwId = entity.Id, SternId = _model.Id });
            }

            #endregion
        }
    }
}
