using MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Filter;
using MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Production.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using System.Linq;

namespace MOROPO.Framework.Decisor.Production.Presentation.Web.Frontend.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/fwrk/production/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class ProductionsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementFilteredController<Persistence.Entities.Production, System.Guid, ProductionInputModel, ProductionDisplayModel, ProductionFilterModel>
    {
        private readonly IEntityRepository<ElaborationStep, System.Guid> stepRepository;

        public ProductionsController(IEntityRepository<ElaborationStep, System.Guid> stepRepository, IEntityRepository<Persistence.Entities.Production, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<ProductionsController> localizer, Microsoft.Extensions.Logging.ILogger<ProductionsController> logger) : base(repository, localizer, logger)
        {
            this.stepRepository = stepRepository;
        }

        protected override System.Linq.Expressions.Expression<System.Func<Persistence.Entities.Production, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived && entity.Enabled;
        }

        public override Microsoft.AspNetCore.Mvc.ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        protected override ProductionDisplayModel EntityToDisplayModel(Persistence.Entities.Production entity)
        {
            var model = base.EntityToDisplayModel(entity);

            var steps = stepRepository.FindBy(_entity => _entity.ElaborationId == entity.Order.ElaborationId).ToArray();

            model.Order.Elaboration.Steps = steps.Select(_entity =>
            {
                var _model = new ElaborationStepDisplayModel();

                _model.Import(_entity);

                return _model;
            }).ToArray();

            return model;
        }
    }
}
