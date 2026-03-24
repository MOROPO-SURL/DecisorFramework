using MOROPO.Framework.Decisor.Domain.Persistence.Entities;
using MOROPO.Framework.Decisor.Domain.Presentation.Web.Common.Extensions;
using MOROPO.Framework.Decisor.Domain.Presentation.Web.Frontend.Extensions;
using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Filter;
using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.HumanResources.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using System.Linq;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Web.Frontend.Controllers.API;

[Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
[Microsoft.AspNetCore.Mvc.Route("api/fwrk/hhrr/[controller]")]
[Microsoft.AspNetCore.Mvc.ApiController]
public class WorkforcesController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementFilteredController<Workforce, System.Guid, WorkforceInputModel, WorkforceDisplayModel, WorkforceFilterModel>
{
    private readonly IEntityRepository<Vacant, System.Guid> vacantRepository;
    private readonly IEntityRepository<WorkforceOrganizationalUnit, System.Guid> organizationalUnitRepository;
    private readonly IEntityRepository<OrganizationalStructuringUnit, System.Guid> organizationalStructuringUnityRepository;
    private readonly IEntityRepository<ChangeNotification, System.Guid> changeNotificationRepository;

    public WorkforcesController(IEntityRepository<ChangeNotification, System.Guid> changeNotificationRepository, IEntityRepository<OrganizationalStructuringUnit, System.Guid> organizationalStructuringUnityRepository, IEntityRepository<WorkforceOrganizationalUnit, System.Guid> organizationalUnitRepository, IEntityRepository<Vacant, System.Guid> vacantRepository, IEntityRepository<Workforce, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<WorkforcesController> localizer, Microsoft.Extensions.Logging.ILogger<WorkforcesController> logger)
        : base(repository, localizer, logger)
    {
        this.vacantRepository = vacantRepository;
        this.organizationalUnitRepository = organizationalUnitRepository;
        this.organizationalStructuringUnityRepository = organizationalStructuringUnityRepository;
        this.changeNotificationRepository = changeNotificationRepository;
    }

    protected override System.Linq.Expressions.Expression<System.Func<Workforce, bool>> GetGlobalSelector()
    {
        return entity => !entity.Archived;
    }

    protected override System.Func<Workforce, object> GetOrderSelector()
    {
        return entity => entity.Priority;
    }

    public override Microsoft.AspNetCore.Mvc.ActionResult Delete(System.Guid key)
    {
        return NotFound();
    }

    protected override WorkforceDisplayModel EntityToDisplayModel(Workforce entity)
    {
        var result = base.EntityToDisplayModel(entity);

        result.OrganizationalStructure.RootStructuringUnit = entity.OrganizationalStructure.RootStructuringUnit.GetInteropChildren(organizationalStructuringUnityRepository);

        result.OrganizationalUnits = organizationalUnitRepository.FindBy(_entity => _entity.WorkforceId == entity.Id).ToArray().Select(_entity =>
        {
            var _model = new WorkforceOrganizationalUnitDisplayModel();

            _model.Import(_entity);

            if (_entity.ChiefVacantId != null)
            {
                _model.ChiefVacant.WorkforceOrganizationalUnit = new WorkforceOrganizationalUnitDisplayModel();

                _model.ChiefVacant.WorkforceOrganizationalUnit.Import(_entity);

                _model.Vacants = vacantRepository.FindBy(__entity => __entity.WorkforceOrganizationalUnitId == _entity.Id && __entity.Id != _entity.ChiefVacant.Id).OrderBy(__entity => __entity.Priority).ToArray().Select(__entity =>
                {
                    var __model = new VacantDisplayModel();

                    __model.Import(__entity);

                    __model.WorkforceOrganizationalUnit = new WorkforceOrganizationalUnitDisplayModel();

                    __model.WorkforceOrganizationalUnit.Import(_entity);

                    return __model;
                }).ToArray();
            }
            else
            {
                _model.Vacants = vacantRepository.FindBy(__entity => __entity.WorkforceOrganizationalUnitId == _entity.Id).OrderBy(__entity => __entity.Priority).ToArray().Select(__entity =>
                {
                    var __model = new VacantDisplayModel();

                    __model.Import(__entity);

                    __model.WorkforceOrganizationalUnit = new WorkforceOrganizationalUnitDisplayModel();

                    __model.WorkforceOrganizationalUnit.Import(_entity);

                    return __model;
                }).ToArray();
            }

            return _model;
        }).ToArray();

        return result;
    }

    protected override void PreCreate(Workforce entity, WorkforceInputModel model)
    {
        base.PreCreate(entity, model);

        foreach (var _model in model.IncomingOrganizationalUnits)
        {
            var _entity = _model.Export();

            _entity.WorkforceId = entity.Id;

            if (_model.ChiefVacant != null)
            {
                var __entity = _model.ChiefVacant.Export();

                __entity.WorkforceOrganizationalUnitId = _entity.Id;

                vacantRepository.Add(__entity, User.Identity.Name, false);
            }

            foreach (var __model in _model.IncomingVacants)
            {
                var __entity = __model.Export();

                __entity.WorkforceOrganizationalUnitId = _entity.Id;

                vacantRepository.Add(__entity, User.Identity.Name, false);
            }

            organizationalUnitRepository.Add(_entity, User.Identity.Name, false);
        }
    }

    protected override void PostCreate(Workforce entity, WorkforceInputModel model)
    {
        base.PostCreate(entity, model);

        this.ChangeNotificationOnPostCreate(entity, model, changeNotificationRepository);

        bool updateRequited = false;

        foreach (var _model in model.IncomingOrganizationalUnits)
        {
            var _entity = organizationalUnitRepository.Get(_model.Id);

            if (_model.ChiefVacant != null)
            {
                _entity.ChiefVacantId = _model.ChiefVacant.Id;

                organizationalUnitRepository.Update(_entity, User.Identity.Name, false);

                updateRequited = true;
            }
        }

        if (!updateRequited) return;

        Repository.Update(entity, User.Identity.Name);
    }

    protected override void PreEdit(Workforce entity, WorkforceInputModel model)
    {
        base.PreEdit(entity, model);

        foreach (var _model in model.OutgoingOrganizationalUnits)
        {
            organizationalUnitRepository.Delete(new WorkforceOrganizationalUnit { Id = _model.Id }, User.Identity.Name, false);
        }

        foreach (var _model in model.EditionOrganizationalUnits)
        {
            var _entity = organizationalUnitRepository.Get(_model.Id);

            if (_model.ChiefVacant != null)
            {
                if (_entity.ChiefVacant != null)
                {
                    _model.ChiefVacant.Mergue(_entity.ChiefVacant);

                    vacantRepository.Update(_entity.ChiefVacant, User.Identity.Name, false);
                }
                else
                {
                    var __entity = _model.ChiefVacant.Export();

                    __entity.WorkforceOrganizationalUnitId = _entity.Id;

                    vacantRepository.Add(__entity, User.Identity.Name, false);
                }
            }

            foreach (var __model in _model.OutgoingVacants)
            {
                vacantRepository.Delete(new Vacant { Id = __model.Id }, User.Identity.Name, false);
            }

            foreach (var __model in _model.EditionVacants)
            {
                var __entity = vacantRepository.Get(__model.Id);

                __model.Mergue(__entity);

                vacantRepository.Update(__entity, User.Identity.Name, false);
            }

            foreach (var __model in _model.IncomingVacants)
            {
                var __entity = __model.Export();

                __entity.WorkforceOrganizationalUnitId = _entity.Id;

                vacantRepository.Add(__entity, User.Identity.Name, false);
            }
        }

        foreach (var _model in model.IncomingOrganizationalUnits)
        {
            var _entity = _model.Export();

            _entity.WorkforceId = entity.Id;

            if (_model.ChiefVacant != null)
            {
                var __entity = _model.ChiefVacant.Export();

                __entity.WorkforceOrganizationalUnitId = _entity.Id;

                vacantRepository.Add(__entity, User.Identity.Name, false);
            }

            foreach (var __model in _model.IncomingVacants)
            {
                var __entity = __model.Export();

                __entity.WorkforceOrganizationalUnitId = _entity.Id;

                vacantRepository.Add(__entity, User.Identity.Name, false);
            }

            organizationalUnitRepository.Add(_entity, User.Identity.Name, false);
        }
    }

    protected override void PostEdit(Workforce entity, WorkforceInputModel model)
    {
        base.PostEdit(entity, model);

        this.ChangeNotificationOnPostEdit(entity, model, changeNotificationRepository);

        bool updateRequited = false;

        foreach (var _model in model.EditionOrganizationalUnits)
        {
            var _entity = organizationalUnitRepository.Get(_model.Id);

            if (_model.ChiefVacant != null)
            {
                if (_entity.ChiefVacant == null)
                {
                    _entity.ChiefVacantId = _model.ChiefVacant.Id;

                    organizationalUnitRepository.Update(_entity, User.Identity.Name, false);

                    updateRequited = true;
                }
            }
        }

        foreach (var _model in model.IncomingOrganizationalUnits)
        {
            var _entity = organizationalUnitRepository.Get(_model.Id);

            if (_model.ChiefVacant != null)
            {
                _entity.ChiefVacantId = _model.ChiefVacant.Id;

                organizationalUnitRepository.Update(_entity, User.Identity.Name, false);

                updateRequited = true;
            }
        }

        if (!updateRequited) return;

        Repository.Update(entity, User.Identity.Name);
    }
}