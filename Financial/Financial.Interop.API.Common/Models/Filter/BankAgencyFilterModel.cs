namespace MOROPO.Framework.Decisor.Financial.Interop.API.Common.Models.Filter
{
    public class BankAgencyFilterModel : Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.BankAgency, System.Guid>
    {
        public string Parameter { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.BankAgency, bool>> GetSelector()
        {
            return entity => entity.Name.ToLower().Contains(Parameter.ToLower()) || entity.Alias.ToLower().Contains(Parameter.ToLower());
        }
    }
}
