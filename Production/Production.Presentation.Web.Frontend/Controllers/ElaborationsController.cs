using Microsoft.Extensions.Logging;
using MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Production.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using System.Linq;

namespace MOROPO.Framework.Decisor.Production.Presentation.Web.Frontend.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/production/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class ElaborationsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEntityAPIManagementController<Elaboration, System.Guid, ElaborationInputModel, ElaborationDisplayModel>
    {
        private readonly IEntityRepository<ElaborationStep, System.Guid> stepRepository;

        public ElaborationsController(IEntityRepository<ElaborationStep, System.Guid> stepRepository, IEntityRepository<Elaboration, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<ElaborationsController> localizer, ILogger<ElaborationsController> logger) : base(repository, localizer, logger)
        {
            this.stepRepository = stepRepository;
        }

        protected override System.Linq.Expressions.Expression<System.Func<Elaboration, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived && entity.Enabled;
        }

        protected override System.Func<Elaboration, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }

        public override Microsoft.AspNetCore.Mvc.ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        protected override ElaborationDisplayModel EntityToDisplayModel(Elaboration entity)
        {
            var steps = stepRepository.FindBy(_entity => _entity.ElaborationId == entity.Id).ToArray();

            var model = base.EntityToDisplayModel(entity);

            model.Steps = steps.Select(_entity =>
            {
                var _model = new ElaborationStepDisplayModel();

                _model.Import(_entity);

                return _model;
            }).ToArray();

            return model;
        }

        protected override void PreCreate(Elaboration entity, ElaborationInputModel model)
        {
            base.PreCreate(entity, model);

            if (model.Steps != null)
            {
                foreach (var _model in model.Steps)
                {
                    var _entity = stepRepository.Add(new ElaborationStep
                    {
                        Id = _model.Id,
                        Name = _model.Name,
                        ElaborationId = entity.Id,
                        Description = _model.Description,
                        MinDecrease = _model.MinDecrease,
                        MaxDecrease = _model.MaxDecrease,
                        Priority = _model.Priority,
                        ProductionRoleBridges = _model.ProductionRoles.Select(__model => new ElaborationStepProductionRoleBridge
                        {
                            ProwId = _model.Id,
                            SternId = __model.Role.Id,
                            Participation = __model.Participation,
                            Linked = __model.Linked,
                            Description = __model.Description
                        }).ToList()
                    }, User.Identity.Name, false);
                }
            }
        }

        protected override void PreEdit(Elaboration entity, ElaborationInputModel model)
        {
            base.PreEdit(entity, model);

            var steps = stepRepository.FindBy(_entity => _entity.ElaborationId == entity.Id).ToArray();

            foreach (var _entity in steps)
            {
                stepRepository.Delete(_entity, User.Identity.Name, false);
            }

            if (model.Steps != null)
            {
                foreach (var _model in model.Steps)
                {
                    stepRepository.Add(new ElaborationStep
                    {
                        Id = _model.Id,
                        Name = _model.Name,
                        ElaborationId = entity.Id,
                        Description = _model.Description,
                        MinDecrease = _model.MinDecrease,
                        MaxDecrease = _model.MaxDecrease,
                        Priority = _model.Priority,
                        ProductionRoleBridges = _model.ProductionRoles.Select(__model => new ElaborationStepProductionRoleBridge
                        {
                            ProwId = _model.Id,
                            SternId = __model.Role.Id,
                            Participation = __model.Participation,
                            Linked = __model.Linked,
                            Description = __model.Description
                        }).ToList()
                    }, User.Identity.Name, false);
                }
            }
        }
    }
}
