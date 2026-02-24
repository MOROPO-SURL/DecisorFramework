using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Filter;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;
using MOROPO.Framework.Decisor.Domain.Presentation.Web.Frontend.Extensions;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Web.Frontend.Controllers.API
{
    [Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/fwrk/domain/[controller]")]
    [ApiController]
    public class KnowledgeAreasController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEnableableEntityAPIManagementFilteredController<KnowledgeArea, System.Guid, KnowledgeAreaInputModel, KnowledgeAreaDisplayModel, KnowledgeAreaFilterModel>
    {
        private readonly IEntityRepository<ChangeNotification, System.Guid> changeNotificationRepository;

        public KnowledgeAreasController(IEntityRepository<ChangeNotification, System.Guid> changeNotificationRepository, IEntityRepository<KnowledgeArea, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<KnowledgeAreasController> localizer, Microsoft.Extensions.Logging.ILogger<KnowledgeAreasController> logger) : base(repository, localizer, logger)
        {
            this.changeNotificationRepository = changeNotificationRepository;
        }

        protected override System.Func<KnowledgeArea, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }

        public override ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        protected override void PostCreate(KnowledgeArea entity, KnowledgeAreaInputModel model)
        {
            base.PostCreate(entity, model);

            this.ChangeNotificationOnPostCreate(entity, model, changeNotificationRepository);
        }

        protected override void PostEdit(KnowledgeArea entity, KnowledgeAreaInputModel model)
        {
            base.PostEdit(entity, model);

            this.ChangeNotificationOnPostEdit(entity, model, changeNotificationRepository);
        }
    }
}
