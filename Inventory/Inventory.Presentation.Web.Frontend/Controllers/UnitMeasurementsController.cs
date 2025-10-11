using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Decisor.Inventory.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Inventory.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Inventory.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using System.Linq;

namespace MOROPO.Framework.Decisor.Inventory.Presentation.Web.Frontend.Controllers
{
    [Route("api/fwrk/inventory/[controller]")]
    [ApiController]
    public class UnitMeasurementsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementController<UnitMeasurement, System.Guid, UnitMeasurementInputModel, UnitMeasurementDisplayModel>
    {
        private readonly IBridgeRepository<UnitMeasurementConversionBridge, UnitMeasurement, System.Guid, UnitMeasurement, System.Guid> unitMeasurementConversionBridgeRepository;

        public UnitMeasurementsController(IBridgeRepository<UnitMeasurementConversionBridge, UnitMeasurement, System.Guid, UnitMeasurement, System.Guid> unitMeasurementConversionBridgeRepository, IEntityRepository<UnitMeasurement, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<UnitMeasurementsController> localizer, Microsoft.Extensions.Logging.ILogger<UnitMeasurementsController> logger)
            : base(repository, localizer, logger)
        {
            this.unitMeasurementConversionBridgeRepository = unitMeasurementConversionBridgeRepository;
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

        protected override void PreCreate(UnitMeasurement entity, UnitMeasurementInputModel model)
        {
            base.PreCreate(entity, model);

            foreach (var _model in model.IncomingConvertions)
            {
                entity.ConversionBridges.Add(new UnitMeasurementConversionBridge { ProwId = entity.Id, SternId = _model.Destination.Id, Convertion = _model.Convertion });

                unitMeasurementConversionBridgeRepository.Add(new UnitMeasurementConversionBridge { ProwId = _model.Destination.Id, SternId = entity.Id, Convertion = 1 / _model.Convertion }, User.Identity.Name, false);
            }
        }

        protected override void PreEdit(UnitMeasurement entity, UnitMeasurementInputModel model)
        {
            base.PreEdit(entity, model);

            foreach (var _model in model.OutgoingConvertions)
            {
                var bridge = entity.ConversionBridges.First(_bridge => _bridge.SternId == _model.Destination.Id);

                unitMeasurementConversionBridgeRepository.Delete(bridge, User.Identity.Name, false);
                unitMeasurementConversionBridgeRepository.Delete(unitMeasurementConversionBridgeRepository.Get(_model.Destination.Id, entity.Id), User.Identity.Name, false);
            }

            foreach (var _model in model.EditionConvertions)
            {
                var bridge = entity.ConversionBridges.First(_bridge => _bridge.SternId == _model.Destination.Id);

                bridge.Convertion = _model.Convertion;

                unitMeasurementConversionBridgeRepository.Delete(unitMeasurementConversionBridgeRepository.Get(_model.Destination.Id, entity.Id), User.Identity.Name, false);
                unitMeasurementConversionBridgeRepository.Add(new UnitMeasurementConversionBridge { ProwId = _model.Destination.Id, SternId = entity.Id, Convertion = 1 / _model.Convertion }, User.Identity.Name, false);
            }

            foreach (var _model in model.IncomingConvertions)
            {
                entity.ConversionBridges.Add(new UnitMeasurementConversionBridge { ProwId = entity.Id, SternId = _model.Destination.Id, Convertion = _model.Convertion });

                unitMeasurementConversionBridgeRepository.Add(new UnitMeasurementConversionBridge { ProwId = _model.Destination.Id, SternId = entity.Id, Convertion = 1 / _model.Convertion }, User.Identity.Name, false);
            }
        }

        [HttpGet("releateds/{key}")]
        public ActionResult<UnitMeasurementDisplayModel[]> GetReleateds(System.Guid key)
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