namespace MOROPO.Framework.Decisor.Governance.Interop.API.Common.Models.Filter
{
    public class DecisionMakingGroupFilterModel : Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.DecisionMakingGroup, System.Guid>
    {
        public string Parameter { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.DecisionMakingGroup, bool>> GetSelector()
        {
            return entity => entity.Name.ToLower().Contains(Parameter.ToLower()) || entity.AdministrativeEntity.Identity.Name.Contains(Parameter.ToLower());
        }
    }
}
