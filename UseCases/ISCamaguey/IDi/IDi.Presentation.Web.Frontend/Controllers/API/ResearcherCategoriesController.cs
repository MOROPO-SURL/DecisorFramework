using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Web.Frontend.Controllers.API;

[Route("api/idi/[controller]")]
[ApiController]
public class ResearcherCategoriesController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEnableableEntityAPIConsultController<ResearcherCategory, System.Guid, ResearcherCategoryDisplayModel>
{
    public ResearcherCategoriesController(IEntityRepository<ResearcherCategory, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<ResearcherCategoriesController> localizer, Microsoft.Extensions.Logging.ILogger<ResearcherCategoriesController> logger) : base(repository, localizer, logger)
    {
    }

    protected override System.Linq.Expressions.Expression<System.Func<ResearcherCategory, bool>> GetGlobalSelector()
    {
        return entity => !entity.Archived;
    }

    protected override System.Func<ResearcherCategory, object> GetOrderSelector()
    {
        return entity => entity.Priority;
    }
}
