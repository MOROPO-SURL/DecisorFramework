namespace MOROPO.Framework.Decisor.Commercial.Presentation.Web.Frontend.Controllers.API
{
    [Microsoft.AspNetCore.Mvc.Route("api/commercial/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class NaturalBusinessKindsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEntityAPIConsultController<Persistence.Entities.NaturalBusinessKind, System.Guid, Interop.API.Common.Models.Display.NaturalBusinessKindDisplayModel>
    {
        public NaturalBusinessKindsController(Guama.Core.Persistence.Repositories.IEntityRepository<Persistence.Entities.NaturalBusinessKind, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<NaturalBusinessKindsController> localizer, Microsoft.Extensions.Logging.ILogger<NaturalBusinessKindsController> logger)
            : base(repository, localizer, logger)
        {
        }

        protected override System.Linq.Expressions.Expression<System.Func<Persistence.Entities.NaturalBusinessKind, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived && entity.Enabled;
        }

        protected override System.Func<Persistence.Entities.NaturalBusinessKind, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }
    }
}