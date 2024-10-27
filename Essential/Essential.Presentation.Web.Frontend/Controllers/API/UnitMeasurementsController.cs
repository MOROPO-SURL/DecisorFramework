using Microsoft.AspNetCore.Mvc;
using System.Linq;
using MOROPO.Framework.Decisor.Essential.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Essential.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Essential.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Essential.Presentation.Web.Frontend.Controllers.API
{
    [Route("api/[controller]")]
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