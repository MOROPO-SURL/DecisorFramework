using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.GovCamaguey.Decisor.Prototype.Persistence.Entities;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Web.BackOffice.Controllers.Frontend
{
    [Route("api/governance/[controller]")]
    [ApiController]
    public class UnitMeasurementsController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEnableableEntityAPIManagementController<UnitMeasurement, System.Guid, Interop.API.Common.Models.Input.UnitMeasurementInputModel, Interop.API.Common.Models.Display.UnitMeasurementDisplayModel>
    {
        public UnitMeasurementsController(IEntityRepository<UnitMeasurement, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<UnitMeasurementsController> localizer, Microsoft.Extensions.Logging.ILogger<UnitMeasurementsController> logger)
            : base(repository, localizer, logger)
        {
        }

        protected override System.Linq.Expressions.Expression<System.Func<UnitMeasurement, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<UnitMeasurement, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }

        public override ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }
    }
}