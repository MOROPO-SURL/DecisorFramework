using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Core.Presentation.Models;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;
using MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Display;
using MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Input;
using MOROPO.GovCamaguey.Decisor.Prototype.Persistence.Entities;
using System.Linq;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Web.BackOffice.Controllers.Frontend;

[Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
[Route("api/governance/[controller]")]
[ApiController]
public class ObjectivesController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEnableableEntityAPIManagementController<Objective, System.Guid, ObjectiveInputModel, ObjectiveDisplayModel>
{
    private readonly IEntityRepository<Proyection, System.Guid> proyectionRepository;
    private readonly IEntityRepository<ProyectionIndicator, System.Guid> proyectionIndicatorRepository;
    private readonly IEntityRepository<ProyectionIndicatorMontlyPlan, System.Guid> proyectionIndicatorMontlyPlanRepository;
    private readonly IEntityRepository<Action, System.Guid> actionRepository;
    private readonly IEntityRepository<ActionMonthlyClosure, System.Guid> actionMonthlyClosureRepository;
    private readonly IEntityRepository<ActionIndicator, System.Guid> actionIndicatorRepository;
    private readonly IEntityRepository<ActionIndicatorMontlyPlan, System.Guid> actionIndicatorMontlyPlanRepository;
    private readonly IEntityRepository<ObjectiveIndicator, System.Guid> objectiveIndicatorRepository;
    private readonly IEntityRepository<ObjectiveIndicatorMontlyPlan, System.Guid> objectiveIndicatorMontlyPlanRepository;

    public ObjectivesController(
        IEntityRepository<ObjectiveIndicatorMontlyPlan, System.Guid> objectiveIndicatorMontlyPlanRepository, 
        IEntityRepository<ObjectiveIndicator, System.Guid> objectiveIndicatorRepository, 
        IEntityRepository<ActionIndicatorMontlyPlan, System.Guid> actionIndicatorMontlyPlanRepository, 
        IEntityRepository<ActionIndicator, System.Guid> actionIndicatorRepository, 
        IEntityRepository<ActionMonthlyClosure, System.Guid> actionMonthlyClosureRepository, 
        IEntityRepository<Action, System.Guid> actionRepository,
        IEntityRepository<ProyectionIndicatorMontlyPlan, System.Guid> proyectionIndicatorMontlyPlanRepository,
        IEntityRepository<ProyectionIndicator, System.Guid> proyectionIndicatorRepository,
        IEntityRepository<Proyection, System.Guid> proyectionRepository, 
        IEntityRepository<Objective, System.Guid> repository, 
        Microsoft.Extensions.Localization.IStringLocalizer<ObjectivesController> localizer, 
        Microsoft.Extensions.Logging.ILogger<ObjectivesController> logger)
        : base(repository, localizer, logger)
    {
        this.proyectionRepository = proyectionRepository;
        this.proyectionIndicatorRepository = proyectionIndicatorRepository;
        this.proyectionIndicatorMontlyPlanRepository = proyectionIndicatorMontlyPlanRepository;
        this.actionRepository = actionRepository;
        this.actionMonthlyClosureRepository = actionMonthlyClosureRepository;
        this.actionIndicatorRepository = actionIndicatorRepository;
        this.actionIndicatorMontlyPlanRepository = actionIndicatorMontlyPlanRepository;
        this.objectiveIndicatorRepository = objectiveIndicatorRepository;
        this.objectiveIndicatorMontlyPlanRepository = objectiveIndicatorMontlyPlanRepository;
    }

    protected override System.Linq.Expressions.Expression<System.Func<Objective, bool>> GetGlobalSelector()
    {
        return entity => !entity.Archived;
    }

    protected override System.Func<Objective, object> GetOrderSelector()
    {
        return entity => entity.Index;
    }

    protected override ObjectiveDisplayModel EntityToDisplayModel(Objective entity)
    {
        var model = base.EntityToDisplayModel(entity);

        if (model.Responsible.Identity.Image != null)
        {
            model.Responsible.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Responsible.Identity.Image.ContentType);
        }

        foreach (var proyection in entity.Proyections)
        {
            var item = model.Proyections.First(_model => _model.Id == proyection.Id);

            foreach (var bridge in proyection.OrganizationResponsabilityBridges)
            {
                if (bridge.Stern.Identity.Image == null) continue;

                var target = item.ResponsabilityOrganizations.First(_model => _model.Id == bridge.SternId);

                target.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(bridge.Stern.Identity.Image.ContentType);
            }

            foreach (var bridge in proyection.OrganizationParticipationBridges)
            {
                if (bridge.Stern.Identity.Image == null) continue;

                var target = item.ParticipationOrganizations.First(_model => _model.Id == bridge.SternId);

                target.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(bridge.Stern.Identity.Image.ContentType);
            }

            foreach (var action in proyection.Actions)
            {
                var _item = item.Actions.First(_model => _model.Id == action.Id);

                foreach (var bridge in action.OrganizationResponsabilityBridges)
                {
                    if (bridge.Stern.Identity.Image == null) continue;

                    var target = _item.ResponsabilityOrganizations.First(_model => _model.Id == bridge.SternId);

                    target.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(bridge.Stern.Identity.Image.ContentType);
                }

                foreach (var bridge in action.OrganizationParticipationBridges)
                {
                    if (bridge.Stern.Identity.Image == null) continue;

                    var target = _item.ParticipationOrganizations.First(_model => _model.Id == bridge.SternId);

                    target.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(bridge.Stern.Identity.Image.ContentType);
                }
            }
        }

        return model;
    }

    public override ActionResult Delete(System.Guid key)
    {
        return NotFound();
    }

    public override ActionResult Enable(System.Guid key)
    {
        return NotFound(key);
    }

    public override ActionResult Disable(System.Guid key)
    {
        return NotFound();
    }

    [RequirePermissions(Interop.API.Common.Constants.Security.Authorization.ObjectiveViewerPermission)]
    public override ActionResult<ObjectiveDisplayModel[]> Get()
    {
        return base.Get();
    }

    [RequirePermissions(Interop.API.Common.Constants.Security.Authorization.ObjectiveViewerPermission)]
    public override ActionResult<ObjectiveDisplayModel> Get(System.Guid key)
    {
        return base.Get(key);
    }

    [RequirePermissions(Interop.API.Common.Constants.Security.Authorization.ObjectiveViewerPermission)]
    public override ActionResult<PaginationModel<ObjectiveDisplayModel>> GetPaginate(int sheet = 1, int limit = 25)
    {
        return base.GetPaginate(sheet, limit);
    }

    [RequirePermissions(Interop.API.Common.Constants.Security.Authorization.ObjectiveCreatorPermission)]
    public override ActionResult Create([FromBody] ObjectiveInputModel model)
    {
        return base.Create(model);
    }

    [RequirePermissions(Interop.API.Common.Constants.Security.Authorization.ObjectiveEditorPermission)]
    public override ActionResult Edit([FromBody] ObjectiveInputModel model)
    {
        return base.Edit(model);
    }

    [RequirePermissions(Interop.API.Common.Constants.Security.Authorization.ObjectiveRemoverPermission)]
    public override ActionResult Archive(System.Guid key)
    {
        return base.Archive(key);
    }

    protected override void PreCreate(Objective entity, ObjectiveInputModel model)
    {
        base.PreCreate(entity, model);

        foreach (var _model in model.IncomingIndicators)
        {
            var _entity = _model.Export();

            _entity.ObjectiveId = entity.Id;

            objectiveIndicatorRepository.Add(_entity, User.Identity.Name, false);

            ExtendCreate(_entity, _model);
        }

        foreach (var _model in model.IncomingProyections)
        {
            var _entity = _model.Export();

            _entity.ObjectiveId = entity.Id;

            proyectionRepository.Add(_entity, User.Identity.Name, false);

            ExtendCreate(_entity, _model);
        }
    }

    protected override void PreEdit(Objective entity, ObjectiveInputModel model)
    {
        base.PreEdit(entity, model);

        foreach (var _model in model.OutgoingIndicators)
        {
            var _entity = entity.Indicators.First(bridge => bridge.Id == _model.Id);

            _entity.Archived = true;

            objectiveIndicatorRepository.Update(_entity, User.Identity.Name, false);
        }

        foreach (var _model in model.EditionIndicators)
        {
            var _entity = entity.Indicators.First(bridge => bridge.Id == _model.Id);

            _model.Mergue(_entity);

            objectiveIndicatorRepository.Update(_entity, User.Identity.Name, false);

            ExtendEdit(_entity, _model);
        }

        foreach (var _model in model.IncomingIndicators)
        {
            var _entity = _model.Export();

            _entity.ObjectiveId = entity.Id;

            objectiveIndicatorRepository.Add(_entity, User.Identity.Name, false);

            ExtendCreate(_entity, _model);
        }

        foreach (var _model in model.OutgoingProyections)
        {
            var _entity = entity.Proyections.First(bridge => bridge.Id == _model.Id);

            _entity.Archived = true;

            proyectionRepository.Update(_entity, User.Identity.Name, false);
        }

        foreach (var _model in model.EditionProyections)
        {
            var _entity = entity.Proyections.First(bridge => bridge.Id == _model.Id);

            _model.Mergue(_entity);

            proyectionRepository.Update(_entity, User.Identity.Name, false);

            ExtendEdit(_entity, _model);
        }

        foreach (var _model in model.IncomingProyections)
        {
            var _entity = _model.Export();

            _entity.ObjectiveId = entity.Id;

            proyectionRepository.Add(_entity, User.Identity.Name, false);

            ExtendCreate(_entity, _model);
        }
    }

    protected void ExtendCreate(Proyection entity, ProyectionInputModel model)
    {
        foreach (var _model in model.IncomingIndicators)
        {
            var _entity = _model.Export();

            _entity.ProyectionId = entity.Id;

            proyectionIndicatorRepository.Add(_entity, User.Identity.Name, false);

            ExtendCreate(_entity, _model);
        }

        foreach (var _model in model.IncomingActions)
        {
            var _entity = _model.Export();

            _entity.ProyectionId = entity.Id;

            actionRepository.Add(_entity, User.Identity.Name, false);

            ExtendCreate(_entity, _model);
        }
    }

    protected void ExtendEdit(Proyection entity, ProyectionInputModel model)
    {
        foreach (var _model in model.OutgoingIndicators)
        {
            var _entity = entity.Indicators.First(bridge => bridge.Id == _model.Id);

            _entity.Archived = true;

            proyectionIndicatorRepository.Update(_entity, User.Identity.Name, false);
        }

        foreach (var _model in model.EditionIndicators)
        {
            var _entity = entity.Indicators.First(bridge => bridge.Id == _model.Id);

            _model.Mergue(_entity);

            proyectionIndicatorRepository.Update(_entity, User.Identity.Name, false);

            ExtendEdit(_entity, _model);
        }

        foreach (var _model in model.IncomingIndicators)
        {
            var _entity = _model.Export();

            _entity.ProyectionId = entity.Id;

            proyectionIndicatorRepository.Add(_entity, User.Identity.Name, false);

            ExtendCreate(_entity, _model);
        }

        foreach (var _model in model.OutgoingActions)
        {
            var _entity = entity.Actions.First(bridge => bridge.Id == _model.Id);

            _entity.Archived = true;

            actionRepository.Update(_entity, User.Identity.Name, false);
        }

        foreach (var _model in model.EditionActions)
        {
            var _entity = entity.Actions.First(bridge => bridge.Id == _model.Id);

            _model.Mergue(_entity);

            actionRepository.Update(_entity, User.Identity.Name, false);

            ExtendEdit(_entity, _model);
        }

        foreach (var _model in model.IncomingActions)
        {
            var _entity = _model.Export();

            _entity.ProyectionId = entity.Id;

            actionRepository.Add(_entity, User.Identity.Name, false);

            ExtendCreate(_entity, _model);
        }
    }

    protected void ExtendCreate(Action entity, ActionInputModel model)
    {
        foreach (var _model in model.IncomingIndicators)
        {
            var _entity = _model.Export();

            _entity.ActionId = entity.Id;

            actionIndicatorRepository.Add(_entity, User.Identity.Name, false);

            ExtendCreate(_entity, _model);
        }

        foreach (var _model in model.IncomingMonthlyClosures)
        {
            var _entity = _model.Export();

            _entity.ActionId = entity.Id;

            actionMonthlyClosureRepository.Add(_entity, User.Identity.Name, false);
        }
    }

    protected void ExtendEdit(Action entity, ActionInputModel model)
    {
        foreach (var _model in model.OutgoingIndicators)
        {
            var _entity = entity.Indicators.First(bridge => bridge.Id == _model.Id);

            _entity.Archived = true;

            actionIndicatorRepository.Update(_entity, User.Identity.Name, false);
        }

        foreach (var _model in model.EditionIndicators)
        {
            var _entity = entity.Indicators.First(bridge => bridge.Id == _model.Id);

            _model.Mergue(_entity);

            actionIndicatorRepository.Update(_entity, User.Identity.Name, false);

            ExtendEdit(_entity, _model);
        }

        foreach (var _model in model.IncomingIndicators)
        {
            var _entity = _model.Export();

            _entity.ActionId = entity.Id;

            actionIndicatorRepository.Add(_entity, User.Identity.Name, false);

            ExtendCreate(_entity, _model);
        }

        foreach (var _model in model.OutgoingMonthlyClosures)
        {
            var _entity = entity.MonthlyClosures.First(bridge => bridge.Id == _model.Id);

            actionMonthlyClosureRepository.Delete(_entity, User.Identity.Name, false);
        }

        foreach (var _model in model.EditionMonthlyClosures)
        {
            var _entity = entity.MonthlyClosures.First(bridge => bridge.Id == _model.Id);

            _model.Mergue(_entity);

            actionMonthlyClosureRepository.Update(_entity, User.Identity.Name, false);
        }

        foreach (var _model in model.IncomingMonthlyClosures)
        {
            var _entity = _model.Export();

            _entity.ActionId = entity.Id;

            actionMonthlyClosureRepository.Add(_entity, User.Identity.Name, false);
        }
    }

    protected void ExtendCreate(ObjectiveIndicator entity, ObjectiveIndicatorInputModel model)
    {
        foreach (var _model in model.IncomingMontlyPlans)
        {
            var _entity = _model.Export();

            _entity.IndicatorId = entity.Id;

            objectiveIndicatorMontlyPlanRepository.Add(_entity, User.Identity.Name, false);
        }
    }

    protected void ExtendEdit(ObjectiveIndicator entity, ObjectiveIndicatorInputModel model)
    {
        foreach (var _model in model.OutgoingMontlyPlans)
        {
            var _entity = entity.MontlyPlans.First(bridge => bridge.Id == _model.Id);

            objectiveIndicatorMontlyPlanRepository.Delete(_entity, User.Identity.Name, false);
        }

        foreach (var _model in model.EditionMontlyPlans)
        {
            var _entity = entity.MontlyPlans.First(bridge => bridge.Id == _model.Id);

            _model.Mergue(_entity);

            objectiveIndicatorMontlyPlanRepository.Update(_entity, User.Identity.Name, false);
        }

        foreach (var _model in model.IncomingMontlyPlans)
        {
            var _entity = _model.Export();

            _entity.IndicatorId = entity.Id;

            objectiveIndicatorMontlyPlanRepository.Add(_entity, User.Identity.Name, false);
        }
    }

    protected void ExtendCreate(ProyectionIndicator entity, ProyectionIndicatorInputModel model)
    {
        foreach (var _model in model.IncomingMontlyPlans)
        {
            var _entity = _model.Export();

            _entity.IndicatorId = entity.Id;

            proyectionIndicatorMontlyPlanRepository.Add(_entity, User.Identity.Name, false);
        }
    }

    protected void ExtendEdit(ProyectionIndicator entity, ProyectionIndicatorInputModel model)
    {
        foreach (var _model in model.OutgoingMontlyPlans)
        {
            var _entity = entity.MontlyPlans.First(bridge => bridge.Id == _model.Id);

            proyectionIndicatorMontlyPlanRepository.Delete(_entity, User.Identity.Name, false);
        }

        foreach (var _model in model.EditionMontlyPlans)
        {
            var _entity = entity.MontlyPlans.First(bridge => bridge.Id == _model.Id);

            _model.Mergue(_entity);

            proyectionIndicatorMontlyPlanRepository.Update(_entity, User.Identity.Name, false);
        }

        foreach (var _model in model.IncomingMontlyPlans)
        {
            var _entity = _model.Export();

            _entity.IndicatorId = entity.Id;

            proyectionIndicatorMontlyPlanRepository.Add(_entity, User.Identity.Name, false);
        }
    }

    protected void ExtendCreate(ActionIndicator entity, ActionIndicatorInputModel model)
    {
        foreach (var _model in model.IncomingMontlyPlans)
        {
            var _entity = _model.Export();

            _entity.IndicatorId = entity.Id;

            actionIndicatorMontlyPlanRepository.Add(_entity, User.Identity.Name, false);
        }
    }

    protected void ExtendEdit(ActionIndicator entity, ActionIndicatorInputModel model)
    {
        foreach (var _model in model.OutgoingMontlyPlans)
        {
            var _entity = entity.MontlyPlans.First(bridge => bridge.Id == _model.Id);

            actionIndicatorMontlyPlanRepository.Delete(_entity, User.Identity.Name, false);
        }

        foreach (var _model in model.EditionMontlyPlans)
        {
            var _entity = entity.MontlyPlans.First(bridge => bridge.Id == _model.Id);

            _model.Mergue(_entity);

            actionIndicatorMontlyPlanRepository.Update(_entity, User.Identity.Name, false);
        }

        foreach (var _model in model.IncomingMontlyPlans)
        {
            var _entity = _model.Export();

            _entity.IndicatorId = entity.Id;

            actionIndicatorMontlyPlanRepository.Add(_entity, User.Identity.Name, false);
        }
    }
}
