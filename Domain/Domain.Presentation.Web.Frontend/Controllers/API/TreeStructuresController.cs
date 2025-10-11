using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;
using System.Linq;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Web.Frontend.Controllers.API
{
    [Microsoft.AspNetCore.Mvc.Route("api/fwrk/domain/structures/tree")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class TreeStructuresController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEnableableEntityAPIConsultController<Structure, System.Guid, StructureTreeDisplayModel>
    {
        public TreeStructuresController(Guama.Core.Persistence.Repositories.IEntityRepository<Structure, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<TreeStructuresController> localizer, Microsoft.Extensions.Logging.ILogger<TreeStructuresController> logger)
            : base(repository, localizer, logger)
        {
        }

        protected override System.Linq.Expressions.Expression<System.Func<Structure, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived && entity.ParentId == null;
        }

        protected override System.Func<Structure, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }

        protected override StructureTreeDisplayModel EntityToDisplayModel(Structure entity)
        {
            var result = base.EntityToDisplayModel(entity);

            result.Children = GetChildren(entity);

            return result;
        }

        private StructureTreeDisplayModel[] GetChildren(Structure entity)
        {
            var result = new System.Collections.Generic.List<StructureTreeDisplayModel>();

            var children = Repository.FindBy(_entity => !_entity.Archived && _entity.ParentId == entity.Id).OrderBy(_entity => _entity.Priority).ToArray();

            foreach (var child in children)
            {
                var model = new StructureTreeDisplayModel();

                model.Import(child);

                model.Children = GetChildren(child);

                result.Add(model);
            }

            return result.ToArray();
        }
    }
}
