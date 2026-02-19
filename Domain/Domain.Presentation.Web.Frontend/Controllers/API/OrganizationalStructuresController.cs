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
public class OrganizationalStructuresController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEnableableEntityAPIManagementFilteredController<OrganizationalStructure, System.Guid, OrganizationalStructureInputModel, OrganizationalStructureDisplayModel, OrganizationalStructureFilterModel>
{
    private readonly IEntityRepository<OrganizationalStructuringUnit, System.Guid> organizationalStructuringUnityRepository;
    private readonly IEntityRepository<ChangeNotification, System.Guid> changeNotificationRepository;

    public OrganizationalStructuresController(IEntityRepository<ChangeNotification, System.Guid> changeNotificationRepository, IEntityRepository<OrganizationalStructuringUnit, System.Guid> organizationalStructuringUnityRepository, IEntityRepository<OrganizationalStructure, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<OrganizationalStructuresController> localizer, Microsoft.Extensions.Logging.ILogger<OrganizationalStructuresController> logger) : base(repository, localizer, logger)
    {
        this.organizationalStructuringUnityRepository = organizationalStructuringUnityRepository;
        this.changeNotificationRepository = changeNotificationRepository;
    }

    protected override System.Linq.Expressions.Expression<System.Func<OrganizationalStructure, bool>> GetGlobalSelector()
    {
        return entity => !entity.Archived;
    }

    protected override System.Func<OrganizationalStructure, object> GetOrderSelector()
    {
        return entity => entity.Priority;
    }

    public override ActionResult Delete(System.Guid key)
    {
        return NotFound();
    }

    protected override OrganizationalStructureDisplayModel EntityToDisplayModel(OrganizationalStructure entity)
    {
        var result = base.EntityToDisplayModel(entity);

        result.RootStructuringUnit = GetChildren(entity.RootStructuringUnit);

        return result;
    }

    protected override void PreCreate(OrganizationalStructure entity, OrganizationalStructureInputModel model)
    {
        base.PreCreate(entity, model);

        var _entity = organizationalStructuringUnityRepository.Add(model.RootStructuringUnit.Export(), User.Identity.Name, false);

        entity.RootStructuringUnitId = _entity.Id;
        entity.RootStructuringUnit = _entity;

        foreach (var _model in model.IncomingStructuringUnits)
        {
            organizationalStructuringUnityRepository.Add(_model.Export(), User.Identity.Name, false);
        }
    }

    protected override void PostCreate(OrganizationalStructure entity, OrganizationalStructureInputModel model)
    {
        base.PostCreate(entity, model);

        this.ChangeNotificationOnPostCreate(entity, model, changeNotificationRepository);
    }

    protected override void PreEdit(OrganizationalStructure entity, OrganizationalStructureInputModel model)
    {
        base.PreEdit(entity, model);

        model.RootStructuringUnit.Mergue(entity.RootStructuringUnit);

        organizationalStructuringUnityRepository.Update(entity.RootStructuringUnit, User.Identity.Name, false);

        foreach (var _model in model.OutgoingStructuringUnits)
        {
            organizationalStructuringUnityRepository.Delete(new OrganizationalStructuringUnit { Id = _model.Id }, User.Identity.Name, false);
        }

        foreach (var _model in model.EditionStructuringUnits)
        {
            var _entity = organizationalStructuringUnityRepository.Get(_model.Id);

            _model.Mergue(_entity);

            organizationalStructuringUnityRepository.Update(_entity, User.Identity.Name, false);
        }

        foreach (var _model in model.IncomingStructuringUnits)
        {
            organizationalStructuringUnityRepository.Add(_model.Export(), User.Identity.Name, false);
        }
    }

    protected override void PostEdit(OrganizationalStructure entity, OrganizationalStructureInputModel model)
    {
        base.PostEdit(entity, model);

        this.ChangeNotificationOnPostEdit(entity, model, changeNotificationRepository);
    }

    private OrganizationalStructuringUnitDisplayModel GetChildren(OrganizationalStructuringUnit entity)
    {
        var result = new OrganizationalStructuringUnitDisplayModel();

        result.Import(entity);

        var children = organizationalStructuringUnityRepository.FindBy(_entity => _entity.ParentId == entity.Id).OrderBy(_entity => _entity.OrganizationalUnit.Priority).ToArray();

        var resultChildren = new System.Collections.Generic.List<OrganizationalStructuringUnitDisplayModel>();

        foreach (var child in children)
        {
            resultChildren.Add(GetChildren(child));
        }

        result.Children = resultChildren.ToArray();

        return result;
    }
}