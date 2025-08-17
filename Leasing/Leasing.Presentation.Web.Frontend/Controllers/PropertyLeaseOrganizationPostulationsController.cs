using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        public PropertyLeaseOrganizationPostulationsController(IEntityRepository<PropertyLeaseOrganizationPostulation, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<PropertyLeaseOrganizationPostulationsController> localizer, ILogger<PropertyLeaseOrganizationPostulationsController> logger) : base(repository, localizer, logger)
        {
        }

        protected override void PreCreate(PropertyLeaseOrganizationPostulation entity, PropertyLeaseOrganizationPostulationInputModel model)
        {
            base.PreCreate(entity, model);

            foreach (var _model in model.IncomingSpaces)
            {
                entity.PropertySpaceBridges.Add(new PropertyLeaseOrganizationPostulationPropertySpaceLeasePropousalBridge { ProwId = entity.Id, SternId = _model.Id });
            }
        }

        protected override void PreEdit(PropertyLeaseOrganizationPostulation entity, PropertyLeaseOrganizationPostulationInputModel model)
        {
            base.PreEdit(entity, model);

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
