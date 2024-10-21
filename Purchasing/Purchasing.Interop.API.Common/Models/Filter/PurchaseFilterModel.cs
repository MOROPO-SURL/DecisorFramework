namespace MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Filter
{
    public class PurchaseFilterModel : Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.Purchase, System.Guid>
    {
        public bool HasReception { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.Purchase, bool>> GetSelector()
        {
            return entity => entity.Reception != null == HasReception;
        }
    }
}
