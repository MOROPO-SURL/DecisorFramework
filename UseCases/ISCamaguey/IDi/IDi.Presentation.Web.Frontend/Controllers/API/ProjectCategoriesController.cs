using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Web.Frontend.Controllers.API
{
    [Route("api/idi/[controller]")]
    [ApiController]
    public class ProjectCategoriesController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEnableableEntityAPIConsultController<ProjectCategory, System.Guid, ProjectCategoryDisplayModel>
    {
        public ProjectCategoriesController(IEntityRepository<ProjectCategory, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<ProjectCategoriesController> localizer, Microsoft.Extensions.Logging.ILogger<ProjectCategoriesController> logger) : base(repository, localizer, logger)
        {
        }

        protected override System.Linq.Expressions.Expression<System.Func<ProjectCategory, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<ProjectCategory, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }
    }
}
