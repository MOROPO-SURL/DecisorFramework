using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Web.Frontend.Controllers.API
{
    [Microsoft.AspNetCore.Mvc.Route("api/fwrk/domain/organizationalunities/parental")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class ParentalOrganizationalUnitiesController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementController<OrganizationalUnity, System.Guid, OrganizationalUnityInputModel, OrganizationalUnityParentalDisplayModel>
    {
        public ParentalOrganizationalUnitiesController(Guama.Core.Persistence.Repositories.IEntityRepository<OrganizationalUnity, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<ParentalOrganizationalUnitiesController> localizer, Microsoft.Extensions.Logging.ILogger<ParentalOrganizationalUnitiesController> logger)
            : base(repository, localizer, logger)
        {
        }

        protected override System.Linq.Expressions.Expression<System.Func<OrganizationalUnity, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<OrganizationalUnity, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }

        public override Microsoft.AspNetCore.Mvc.ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        protected override OrganizationalUnityParentalDisplayModel EntityToDisplayModel(OrganizationalUnity entity)
        {
            var result = base.EntityToDisplayModel(entity);

            if (entity.ParentId != null) result.Parent = GetParent(entity);

            return result;
        }

        private OrganizationalUnityParentalDisplayModel GetParent(OrganizationalUnity entity)
        {
            var parent = Repository.Get(entity.ParentId.Value);

            var model = new OrganizationalUnityParentalDisplayModel();

            model.Import(parent);

            if (parent.ParentId != null) model.Parent = GetParent(parent);

            return model;
        }
    }
}
