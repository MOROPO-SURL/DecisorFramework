using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Filter;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;
using MOROPO.Framework.Decisor.Domain.Presentation.Web.Frontend.Extensions;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Web.Frontend.Controllers.API
{
    [Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    [Microsoft.AspNetCore.Mvc.Route("api/fwrk/domain/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class OrganizationalUnitsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEnableableEntityAPIManagementFilteredController<OrganizationalUnit, System.Guid, OrganizationalUnitInputModel, OrganizationalUnitDisplayModel, OrganizationalUnitFilterModel>
    {
        private readonly IEntityRepository<ChangeNotification, System.Guid> changeNotificationRepository;

        public OrganizationalUnitsController(IEntityRepository<ChangeNotification, System.Guid> changeNotificationRepository, IEntityRepository<OrganizationalUnit, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<OrganizationalUnitsController> localizer, Microsoft.Extensions.Logging.ILogger<OrganizationalUnitsController> logger)
            : base(repository, localizer, logger)
        {
            this.changeNotificationRepository = changeNotificationRepository;
        }

        protected override System.Linq.Expressions.Expression<System.Func<OrganizationalUnit, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<OrganizationalUnit, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }

        public override Microsoft.AspNetCore.Mvc.ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        protected override void PostCreate(OrganizationalUnit entity, OrganizationalUnitInputModel model)
        {
            base.PostCreate(entity, model);

            this.ChangeNotificationOnPostCreate(entity, model, changeNotificationRepository);
        }

        protected override void PostEdit(OrganizationalUnit entity, OrganizationalUnitInputModel model)
        {
            base.PostEdit(entity, model);

            this.ChangeNotificationOnPostEdit(entity, model, changeNotificationRepository);
        }
    }
}
