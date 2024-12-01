using Microsoft.Extensions.Logging;
using MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Filter;
using MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Production.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using System.Linq;

namespace MOROPO.Framework.Decisor.Production.Presentation.Web.Frontend.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/production/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class ProductionPlansController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementFilteredController<ProductionPlan, System.Guid, ProductionPlanInputModel, ProductionPlanDisplayModel, ProductionPlanFilterModel>
    {
        private readonly IEntityRepository<ElaborationStep, System.Guid> stepRepository;

        public ProductionPlansController(IEntityRepository<ElaborationStep, System.Guid> stepRepository, IEntityRepository<ProductionPlan, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<ProductionPlansController> localizer, ILogger<ProductionPlansController> logger) : base(repository, localizer, logger)
        {
            this.stepRepository = stepRepository;
        }

        protected override System.Linq.Expressions.Expression<System.Func<ProductionPlan, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        public override Microsoft.AspNetCore.Mvc.ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        protected override ProductionPlanDisplayModel EntityToDisplayModel(ProductionPlan entity)
        {
            var steps = stepRepository.FindBy(_entity => _entity.ElaborationId == entity.ElaborationId).ToArray();

            var model = base.EntityToDisplayModel(entity);

            model.Elaboration.Steps = steps.Select(_entity =>
            {
                var _model = new ElaborationStepDisplayModel();

                _model.Import(_entity);

                return _model;
            }).ToArray();

            return model;
        }

        [Microsoft.AspNetCore.Mvc.HttpPut("approve/{key}")]
        public virtual Microsoft.AspNetCore.Mvc.ActionResult Edit(System.Guid key)
        {
            try
            {
                var entity = Repository.Get(key);

                entity.ApprovedAt = System.DateTime.Now;

                Repository.Update(entity, User.Identity.Name);

                return Ok();
            }
            catch (System.InvalidOperationException e)
            {
                logger.LogError(e.InnerException, e.Message);

                return NoContent();
            }
            catch (System.Exception e)
            {
                logger.LogError(e.InnerException, e.Message);

                return Conflict();
            }
        }
    }
}
