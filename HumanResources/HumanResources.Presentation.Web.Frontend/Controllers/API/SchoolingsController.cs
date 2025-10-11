namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Web.Frontend.Controllers.API
{
    [Microsoft.AspNetCore.Mvc.Route("api/fwrk/hhrr/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class SchoolingsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEntityAPIConsultController<Persistence.Entities.Schooling, System.Guid, Interop.API.Common.Models.Display.SchoolingDisplayModel>
    {
        public SchoolingsController(Guama.Core.Persistence.Repositories.IEntityRepository<Persistence.Entities.Schooling, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<SchoolingsController> localizer, Microsoft.Extensions.Logging.ILogger<SchoolingsController> logger)
            : base(repository, localizer, logger)
        {

        }

        protected override System.Linq.Expressions.Expression<System.Func<Persistence.Entities.Schooling, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived && entity.Enabled;
        }

        protected override System.Func<Persistence.Entities.Schooling, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }
    }
}
