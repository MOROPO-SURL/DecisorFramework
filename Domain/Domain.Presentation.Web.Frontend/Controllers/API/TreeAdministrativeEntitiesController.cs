using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;
using System.Linq;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Web.Frontend.Controllers.API
{
    [Microsoft.AspNetCore.Mvc.Route("api/fwrk/domain/administrative_entities/tree")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class TreeAdministrativeEntitiesController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEnableableEntityAPIConsultController<AdministrativeEntity, System.Guid, AdministrativeEntityTreeDisplayModel>
    {
        public TreeAdministrativeEntitiesController(Guama.Core.Persistence.Repositories.IEntityRepository<AdministrativeEntity, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<TreeAdministrativeEntitiesController> localizer, Microsoft.Extensions.Logging.ILogger<TreeAdministrativeEntitiesController> logger)
            : base(repository, localizer, logger)
        {
        }

        protected override System.Linq.Expressions.Expression<System.Func<AdministrativeEntity, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived && entity.ParentId == null;
        }

        protected override System.Func<AdministrativeEntity, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }

        protected override AdministrativeEntityTreeDisplayModel EntityToDisplayModel(AdministrativeEntity entity)
        {
            var result = base.EntityToDisplayModel(entity);

            result.Children = GetChildren(entity);

            return result;
        }

        private AdministrativeEntityTreeDisplayModel[] GetChildren(AdministrativeEntity entity)
        {
            var result = new System.Collections.Generic.List<AdministrativeEntityTreeDisplayModel>();

            var children = Repository.FindBy(_entity => !_entity.Archived && _entity.ParentId == entity.Id).OrderBy(_entity => _entity.Priority).ToArray();

            foreach (var child in children)
            {
                var model = new AdministrativeEntityTreeDisplayModel();

                model.Import(child);

                model.Children = GetChildren(child);

                result.Add(model);
            }

            return result.ToArray();
        }
    }
}
