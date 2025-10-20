using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Web.Frontend.Controllers.API
{
    [Route("api/idi/[controller]")]
    [ApiController]
    public class TeachingCategoriesController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEnableableEntityAPIConsultController<TeachingCategory, System.Guid, TeachingCategoryDisplayModel>
    {
        public TeachingCategoriesController(IEntityRepository<TeachingCategory, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<TeachingCategoriesController> localizer, Microsoft.Extensions.Logging.ILogger<TeachingCategoriesController> logger) : base(repository, localizer, logger)
        {
        }

        protected override System.Linq.Expressions.Expression<System.Func<TeachingCategory, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<TeachingCategory, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }
    }
}
