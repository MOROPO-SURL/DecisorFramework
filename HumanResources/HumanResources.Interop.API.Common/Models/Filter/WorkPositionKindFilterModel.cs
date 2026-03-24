namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Filter
{
    public class WorkPositionKindFilterModel : Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.WorkPositionKind, System.Guid>
    {
        public string Parameter { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.WorkPositionKind, bool>> GetSelector()
        {
            return entity => entity.Name.ToLower().Contains(Parameter.ToLower());
        }
    }
}
