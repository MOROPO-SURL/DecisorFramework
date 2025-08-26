using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Filter;
using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.HumanResources.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Web.Frontend.Controllers.API
{
    [Microsoft.AspNetCore.Mvc.Route("api/hhrr/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class NamingResolutionsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementFilteredController<NamingResolution, long, NamingResolutionInputModel, NamingResolutionDisplayModel, NamingResolutionFilterModel>
    {
        public NamingResolutionsController(IEntityRepository<NamingResolution, long> repository, Microsoft.Extensions.Localization.IStringLocalizer<NamingResolutionsController> localizer, Microsoft.Extensions.Logging.ILogger<NamingResolutionsController> logger) : base(repository, localizer, logger)
        {
        }

        protected override System.Linq.Expressions.Expression<System.Func<NamingResolution, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<NamingResolution, object> GetOrderSelector()
        {
            return entity => 1000 * entity.Id + entity.At.Year;
        }

        protected override bool IsOrderDescending()
        {
            return true;
        }

        public override Microsoft.AspNetCore.Mvc.ActionResult Delete(long key)
        {
            return NotFound();
        }

        protected override NamingResolutionDisplayModel EntityToDisplayModel(NamingResolution entity)
        {
            var model = base.EntityToDisplayModel(entity);

            if (model.Contact.Identity.Image != null)
            {
                model.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Contact.Identity.Image.ContentType);
            }

            return model;
        }
    }
}
