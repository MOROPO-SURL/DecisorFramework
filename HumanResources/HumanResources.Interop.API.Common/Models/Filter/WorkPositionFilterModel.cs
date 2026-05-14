namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Filter
{
    public class WorkPositionFilterModel : Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.WorkPosition, System.Guid>
    {
        public string Parameter { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.WorkPosition, bool>> GetSelector()
        {
            return entity => entity.Name.ToLower().Contains(Parameter.ToLower()) || entity.Reference.ToLower().Contains(Parameter.ToLower());
        }
    }
}
