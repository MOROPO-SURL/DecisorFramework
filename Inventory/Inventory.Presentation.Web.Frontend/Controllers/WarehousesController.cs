using MOROPO.Framework.Decisor.Domain.Persistence.Entities;
using MOROPO.Framework.Decisor.Domain.Presentation.Web.Frontend.Extensions;
using MOROPO.Framework.Decisor.Inventory.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Inventory.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Inventory.Persistence.Entities;
using MOROPO.Framework.Decisor.Inventory.Presentation.Web.Frontend.Extensions;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using System.Linq;

namespace MOROPO.Framework.Decisor.Inventory.Presentation.Web.Frontend.Controllers;

[Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
[Microsoft.AspNetCore.Mvc.Route("api/fwrk/inventory/[controller]")]
[Microsoft.AspNetCore.Mvc.ApiController]
public class WarehousesController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEnableableEntityAPIManagementController<Warehouse, System.Guid, WarehouseInputModel, WarehouseDisplayModel>
{
    private readonly IEntityRepository<WarehousingArea, System.Guid> warehousingAreaRepository;
    private readonly IEntityRepository<Family, int> familyRepository;
    private readonly IEntityRepository<ChangeNotification, System.Guid> changeNotificationRepository;

    public WarehousesController(IEntityRepository<ChangeNotification, System.Guid> changeNotificationRepository, IEntityRepository<Family, int> familyRepository, IEntityRepository<WarehousingArea, System.Guid> warehousingAreaRepository, IEntityRepository<Warehouse, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<WarehousesController> localizer, Microsoft.Extensions.Logging.ILogger<WarehousesController> logger)
        : base(repository, localizer, logger)
    {
        this.warehousingAreaRepository = warehousingAreaRepository;
        this.familyRepository = familyRepository;
        this.changeNotificationRepository = changeNotificationRepository;
    }

    protected override System.Linq.Expressions.Expression<System.Func<Warehouse, bool>> GetGlobalSelector()
    {
        return entity => !entity.Archived && entity.Enabled;
    }

    protected override System.Func<Warehouse, object> GetOrderSelector()
    {
        return entity => entity.Priority;
    }

    public override Microsoft.AspNetCore.Mvc.ActionResult Delete(System.Guid key)
    {
        return NotFound();
    }

    protected override WarehouseDisplayModel EntityToDisplayModel(Warehouse entity)
    {
        var result = base.EntityToDisplayModel(entity);

        result.Areas = warehousingAreaRepository.FindBy(_entity => _entity.WarehouseId == entity.Id).ToArray().Select(_entity =>
        {
            var model = new WarehousingAreaDisplayModel();

            _entity.Family = familyRepository.Get(_entity.FamilyId);

            _entity.Family.FillParent(familyRepository);

            model.Family = new FamilyDisplayModel();

            model.Family.Import(_entity.Family);

            model.Import(_entity);

            return model;
        }).ToArray();

        return result;
    }

    protected override void PreCreate(Warehouse entity, WarehouseInputModel model)
    {
        base.PreCreate(entity, model);

        foreach (var _model in model.IncomingAreas)
        {
            var _entity = _model.Export();

            _entity.WarehouseId = entity.Id;

            warehousingAreaRepository.Add(_entity, User.Identity.Name, false);
        }
    }

    protected override void PreEdit(Warehouse entity, WarehouseInputModel model)
    {
        base.PreEdit(entity, model);

        foreach (var _model in model.OutgoingAreas)
        {
            warehousingAreaRepository.Delete(new WarehousingArea { Id = _model.Id }, User.Identity.Name, false);
        }

        foreach (var _model in model.EditionAreas)
        {
            var _entity = _model.Export();

            _entity.WarehouseId = entity.Id;

            warehousingAreaRepository.Update(_entity, User.Identity.Name, false);
        }

        foreach (var _model in model.IncomingAreas)
        {
            var _entity = _model.Export();

            _entity.WarehouseId = entity.Id;

            warehousingAreaRepository.Add(_entity, User.Identity.Name, false);
        }
    }

    protected override void PostCreate(Warehouse entity, WarehouseInputModel model)
    {
        base.PostCreate(entity, model);

        this.ChangeNotificationOnPostCreate(entity, model, changeNotificationRepository);
    }

    protected override void PostEdit(Warehouse entity, WarehouseInputModel model)
    {
        base.PostEdit(entity, model);

        this.ChangeNotificationOnPostEdit(entity, model, changeNotificationRepository);
    }
}
