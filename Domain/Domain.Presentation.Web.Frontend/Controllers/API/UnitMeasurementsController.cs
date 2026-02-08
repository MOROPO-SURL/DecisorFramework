using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Filter;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;
using MOROPO.Framework.Decisor.Domain.Presentation.Web.Frontend.Extensions;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using System.Linq;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Web.Frontend.Controllers.API;

[Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
[Route("api/fwrk/domain/[controller]")]
[ApiController]
public class UnitMeasurementsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEnableableEntityAPIManagementFilteredController<UnitMeasurement, System.Guid, UnitMeasurementInputModel, UnitMeasurementDisplayModel, UnitMeasurementFilterModel>
{
    private readonly IBridgeRepository<UnitMeasurementConversionBridge, UnitMeasurement, System.Guid, UnitMeasurement, System.Guid> unitMeasurementConversionBridgeRepository;
    private readonly IEntityRepository<ChangeNotification, System.Guid> changeNotificationRepository;

    public UnitMeasurementsController(IEntityRepository<ChangeNotification, System.Guid> changeNotificationRepository, IBridgeRepository<UnitMeasurementConversionBridge, UnitMeasurement, System.Guid, UnitMeasurement, System.Guid> unitMeasurementConversionBridgeRepository, IEntityRepository<UnitMeasurement, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<UnitMeasurementsController> localizer, Microsoft.Extensions.Logging.ILogger<UnitMeasurementsController> logger)
        : base(repository, localizer, logger)
    {
        this.unitMeasurementConversionBridgeRepository = unitMeasurementConversionBridgeRepository;
        this.changeNotificationRepository = changeNotificationRepository;
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

    protected override void PostCreate(UnitMeasurement entity, UnitMeasurementInputModel model)
    {
        base.PostCreate(entity, model);

        this.ChangeNotificationOnPostCreate(entity, model, changeNotificationRepository);
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

    protected override void PostEdit(UnitMeasurement entity, UnitMeasurementInputModel model)
    {
        base.PostEdit(entity, model);

        this.ChangeNotificationOnPostEdit(entity, model, changeNotificationRepository);
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