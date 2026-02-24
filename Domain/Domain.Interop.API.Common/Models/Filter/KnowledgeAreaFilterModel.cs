
namespace MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Filter
{
    public class KnowledgeAreaFilterModel : Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.KnowledgeArea, System.Guid>
    {
        public string Name { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.KnowledgeArea, bool>> GetSelector()
        {
            return entity => entity.Name.ToLower().Contains(Name.ToLower());
        }
    }
}
