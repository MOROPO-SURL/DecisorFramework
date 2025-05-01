using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Display;
using MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Input;
using MOROPO.GovCamaguey.Decisor.Prototype.Persistence.Entities;
using System.Linq;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Web.BackOffice.Controllers.Frontend
{
    [Route("api/governance/[controller]")]
    [ApiController]
    public class ObjectivesController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEnableableEntityAPIManagementController<Objective, System.Guid, ObjectiveInputModel, ObjectiveDisplayModel>
    {
        private readonly IEntityRepository<Proyection, System.Guid> proyectionRepository;
        private readonly IEntityRepository<Action, System.Guid> actionRepository;
        private readonly IEntityRepository<Indicator, System.Guid> indicatorRepository;

        public ObjectivesController(IEntityRepository<Indicator, System.Guid> indicatorRepository, IEntityRepository<Action, System.Guid> actionRepository, IEntityRepository<Proyection, System.Guid> proyectionRepository, IEntityRepository<Objective, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<ObjectivesController> localizer, Microsoft.Extensions.Logging.ILogger<ObjectivesController> logger)
            : base(repository, localizer, logger)
        {
            this.proyectionRepository = proyectionRepository;
            this.actionRepository = actionRepository;
            this.indicatorRepository = indicatorRepository;
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

        protected override void PreCreate(Objective entity, ObjectiveInputModel model)
        {
            base.PreCreate(entity, model);

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

                indicatorRepository.Add(_entity, User.Identity.Name, false);
            }
        }

        protected void ExtendEdit(Action entity, ActionInputModel model)
        {
            foreach (var _model in model.OutgoingIndicators)
            {
                var _entity = entity.Indicators.First(bridge => bridge.Id == _model.Id);

                _entity.Archived = true;

                indicatorRepository.Update(_entity, User.Identity.Name, false);
            }

            foreach (var _model in model.EditionIndicators)
            {
                var _entity = entity.Indicators.First(bridge => bridge.Id == _model.Id);

                _model.Mergue(_entity);

                indicatorRepository.Update(_entity, User.Identity.Name, false);
            }

            foreach (var _model in model.IncomingIndicators)
            {
                var _entity = _model.Export();

                _entity.ActionId = entity.Id;

                indicatorRepository.Add(_entity, User.Identity.Name, false);
            }
        }
    }
}
