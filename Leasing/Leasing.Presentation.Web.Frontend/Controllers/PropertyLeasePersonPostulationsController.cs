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
    public class PropertyLeasePersonPostulationsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEntityAPIManagementController<PropertyLeasePersonPostulation, System.Guid, PropertyLeasePersonPostulationInputModel, PropertyLeasePersonPostulationDisplayModel>
    {
        public PropertyLeasePersonPostulationsController(IEntityRepository<PropertyLeasePersonPostulation, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<PropertyLeasePersonPostulationsController> localizer, ILogger<PropertyLeasePersonPostulationsController> logger) : base(repository, localizer, logger)
        {
        }

        protected override void PreCreate(PropertyLeasePersonPostulation entity, PropertyLeasePersonPostulationInputModel model)
        {
            base.PreCreate(entity, model);

            foreach (var _model in model.IncomingSpaces)
            {
                entity.PropertySpaceBridges.Add(new PropertyLeasePersonPostulationPropertySpaceLeasePropousalBridge { ProwId = entity.Id, SternId = _model.Id });
            }
        }

        protected override void PreEdit(PropertyLeasePersonPostulation entity, PropertyLeasePersonPostulationInputModel model)
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
                entity.PropertySpaceBridges.Add(new PropertyLeasePersonPostulationPropertySpaceLeasePropousalBridge { ProwId = entity.Id, SternId = _model.Id });
            }

            #endregion
        }
    }
}