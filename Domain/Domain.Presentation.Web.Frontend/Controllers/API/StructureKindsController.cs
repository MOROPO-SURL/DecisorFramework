namespace MOROPO.Framework.Decisor.Domain.Presentation.Web.Frontend.Controllers.API
{
    [Microsoft.AspNetCore.Mvc.Route("api/fwrk/domain/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class StructureKindsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEntityAPIConsultController<Persistence.Entities.StructureKind, System.Guid, Interop.API.Common.Models.Display.StructureKindDisplayModel>
    {
        public StructureKindsController(Guama.Core.Persistence.Repositories.IEntityRepository<Persistence.Entities.StructureKind, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<StructureKindsController> localizer, Microsoft.Extensions.Logging.ILogger<StructureKindsController> logger)
            : base(repository, localizer, logger)
        {

        }

        protected override System.Linq.Expressions.Expression<System.Func<Persistence.Entities.StructureKind, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived && entity.Enabled;
        }

        protected override System.Func<Persistence.Entities.StructureKind, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }
    }
}
