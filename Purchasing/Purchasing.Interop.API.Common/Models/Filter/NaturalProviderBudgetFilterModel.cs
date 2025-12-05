namespace MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Filter
{
    public class NaturalProviderBudgetFilterModel : Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.NaturalProviderBudget, System.Guid>
    {
        public string Parameter { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.NaturalProviderBudget, bool>> GetSelector()
        {
            return entity => entity.Provider.Contact.Identity.Name.ToLower().Contains(Parameter.ToLower()) || entity.Provider.Contact.Identity.LastName.ToLower().Contains(Parameter.ToLower());
        }
    }
}
