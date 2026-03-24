namespace MOROPO.Framework.Decisor.Governance.Interop.API.Common.Models.Filter
{
    public class MeetingFilterModel : Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.Meeting, System.Guid>
    {
        public string Parameter { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.Meeting, bool>> GetSelector()
        {
            return entity => entity.Index.ToString().Contains(Parameter) || entity.DecisionMakingGroup.Name.ToLower().Contains(Parameter.ToLower()) || entity.DecisionMakingGroup.AdministrativeEntity.Identity.Name.Contains(Parameter.ToLower());
        }
    }
}