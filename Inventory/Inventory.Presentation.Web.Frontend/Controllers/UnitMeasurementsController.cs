using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Decisor.Inventory.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Inventory.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Inventory.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Inventory.Presentation.Web.Frontend.Controllers
{
    [Route("api/inventory/[controller]")]
    [ApiController]
    public class UnitMeasurementsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementController<UnitMeasurement, System.Guid, UnitMeasurementInputModel, UnitMeasurementDisplayModel>
    {
        public UnitMeasurementsController(Guama.Core.Persistence.Repositories.IEntityRepository<UnitMeasurement, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<UnitMeasurementsController> localizer, Microsoft.Extensions.Logging.ILogger<UnitMeasurementsController> logger)
            : base(repository, localizer, logger)
        {
        }

        protected override System.Linq.Expressions.Expression<System.Func<UnitMeasurement, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived && entity.Enabled;
        }

        protected override System.Func<UnitMeasurement, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }

        public override ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        [HttpGet("releateds/{key}")]
        public virtual ActionResult<UnitMeasurementDisplayModel[]> GetReleateds(System.Guid key)
        {
            try
            {
                var globalSelector = GetGlobalSelector();

                var entity = Repository.Get(key);

                if (entity.Archived || !entity.Enabled) throw new System.InvalidOperationException();

                var model = new System.Collections.Generic.List<UnitMeasurementDisplayModel>
                {
                    EntityToDisplayModel(entity)
                };

                foreach (var bridge in entity.ConversionBridges)
                {
                    model.Add(EntityToDisplayModel(bridge.Stern));
                }

                return Ok(model);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}