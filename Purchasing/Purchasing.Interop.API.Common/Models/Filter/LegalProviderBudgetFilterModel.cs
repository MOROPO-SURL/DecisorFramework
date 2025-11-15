namespace MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Filter
{
    public class LegalProviderBudgetFilterModel : Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.LegalProviderBudget, System.Guid>
    {
        public string Parameter { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.LegalProviderBudget, bool>> GetSelector()
        {
            return entity => entity.Provider.Contact.Identity.Name.ToLower().Contains(Parameter.ToLower());
        }
    }
}
