using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;
using System.Linq;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Web.Frontend.Controllers.API
{
    [Microsoft.AspNetCore.Mvc.Route("api/fwrk/domain/organizationalunities/tree")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class TreeOrganizationalUnitiesController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEntityAPIConsultController<OrganizationalUnity, System.Guid, OrganizationalUnityTreeDisplayModel>
    {
        public TreeOrganizationalUnitiesController(Guama.Core.Persistence.Repositories.IEntityRepository<OrganizationalUnity, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<TreeOrganizationalUnitiesController> localizer, Microsoft.Extensions.Logging.ILogger<TreeOrganizationalUnitiesController> logger)
            : base(repository, localizer, logger)
        {
        }

        protected override System.Linq.Expressions.Expression<System.Func<OrganizationalUnity, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived && entity.ParentId == null;
        }

        protected override System.Func<OrganizationalUnity, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }

        protected override OrganizationalUnityTreeDisplayModel EntityToDisplayModel(OrganizationalUnity entity)
        {
            var result = base.EntityToDisplayModel(entity);

            result.Children = GetChildren(entity);

            return result;
        }

        private OrganizationalUnityTreeDisplayModel[] GetChildren(OrganizationalUnity entity)
        {
            var result = new System.Collections.Generic.List<OrganizationalUnityTreeDisplayModel>();

            var children = Repository.FindBy(_entity => !_entity.Archived && _entity.ParentId == entity.Id).OrderBy(_entity => _entity.Priority).ToArray();

            foreach (var child in children) 
            {
                var model = new OrganizationalUnityTreeDisplayModel();

                model.Import(child);

                model.Children = GetChildren(child);

                result.Add(model);
            }

            return result.ToArray();
        }
    }
}
