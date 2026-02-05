using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Web.Frontend.Controllers.API
{
    [Route("api/fwrk/domain/[controller]")]
    [ApiController]
    public class KnowledgeAreasController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEnableableEntityAPIManagementController<KnowledgeArea, System.Guid, KnowledgeAreaInputModel, KnowledgeAreaDisplayModel>
    {
        public KnowledgeAreasController(Guama.Core.Persistence.Repositories.IEntityRepository<KnowledgeArea, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<KnowledgeAreasController> localizer, Microsoft.Extensions.Logging.ILogger<KnowledgeAreasController> logger) : base(repository, localizer, logger)
        {
        }

        protected override System.Func<KnowledgeArea, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }

        public override ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }
    }
}
