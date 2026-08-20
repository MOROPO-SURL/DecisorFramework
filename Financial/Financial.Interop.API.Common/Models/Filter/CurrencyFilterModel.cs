namespace MOROPO.Framework.Decisor.Financial.Interop.API.Common.Models.Filter
{
    public class CurrencyFilterModel : Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.Currency, System.Guid>
    {
        public string Parameter { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.Currency, bool>> GetSelector()
        {
            return entity => entity.Name.ToLower().Contains(Parameter.ToLower()) || entity.Symbol.ToLower().Contains(Parameter.ToLower());
        }
    }
}
