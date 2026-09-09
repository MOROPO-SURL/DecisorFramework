using Microsoft.Extensions.Logging;
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
    public class ProductionOrdersController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementFilteredController<ProductionOrder, System.Guid, ProductionOrderInputModel, ProductionOrderDisplayModel, ProductionOrderFilterModel>
    {
        private readonly IEntityRepository<ElaborationStep, System.Guid> stepRepository;

        public ProductionOrdersController(IEntityRepository<ElaborationStep, System.Guid> stepRepository, IEntityRepository<ProductionOrder, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<ProductionOrdersController> localizer, ILogger<ProductionOrdersController> logger) : base(repository, localizer, logger)
        {
            this.stepRepository = stepRepository;
        }

        protected override System.Linq.Expressions.Expression<System.Func<ProductionOrder, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        public override Microsoft.AspNetCore.Mvc.ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        protected override ProductionOrderDisplayModel EntityToDisplayModel(ProductionOrder entity)
        {
            var model = base.EntityToDisplayModel(entity);

            var steps = stepRepository.FindBy(_entity => _entity.ElaborationId == entity.ElaborationId).ToArray();

            if (entity.Elaboration.Product.FeatureImage != null)
            {
                model.Elaboration.Product.FeatureImage.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Elaboration.Product.FeatureImage.ContentType);
            }

            model.Elaboration.Steps = steps.Select(_entity =>
            {
                var _model = new ElaborationStepDisplayModel();

                _model.Import(_entity);

                return _model;
            }).ToArray();

            if (entity.Responsible.Contact.Identity.Image != null)
            {
                model.Responsible.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Responsible.Contact.Identity.Image.ContentType);
            }

            return model;
        }
    }
}
