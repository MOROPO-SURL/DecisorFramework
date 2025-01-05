namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Web.Frontend.Controllers.API
{
    [Microsoft.AspNetCore.Mvc.Route("api/hhrr/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class VacantKindsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEntityAPIConsultController<Persistence.Entities.VacantKind, System.Guid, Interop.API.Common.Models.Display.VacantKindDisplayModel>
    {
        public VacantKindsController(Guama.Core.Persistence.Repositories.IEntityRepository<Persistence.Entities.VacantKind, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<VacantKindsController> localizer, Microsoft.Extensions.Logging.ILogger<VacantKindsController> logger)
            : base(repository, localizer, logger)
        {

        }

        protected override System.Linq.Expressions.Expression<System.Func<Persistence.Entities.VacantKind, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived && entity.Enabled;
        }

        protected override System.Func<Persistence.Entities.VacantKind, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }
    }
}
