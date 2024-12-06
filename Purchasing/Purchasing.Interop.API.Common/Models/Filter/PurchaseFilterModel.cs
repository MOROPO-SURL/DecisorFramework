using MOROPO.Framework.Decisor.Core.Interop.API.Common.Extensions;

namespace MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Filter
{
    public class PurchaseFilterModel : Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.Purchase, System.Guid>
    {
        public bool? HasReception { get; set; }

        public System.DateTime? BeforeAt { get; set; }

        public System.DateTime? AfterAt { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.Purchase, bool>> GetSelector()
        {
            System.Linq.Expressions.Expression<System.Func<Persistence.Entities.Purchase, bool>> expression = null;

            if (HasReception != null)
            {
                expression = entity => entity.Reception != null == HasReception;
            }

            if (AfterAt != null)
            {
                if (expression == null)
                {
                    expression = entity => entity.At >= AfterAt;
                }
                else
                {
                    expression = expression.CombineForAndCondition(entity => entity.At <= AfterAt);
                }
            }

            if (BeforeAt != null)
            {
                if (expression == null)
                {
                    expression = entity => entity.At <= BeforeAt;
                }
                else
                {
                    expression = expression.CombineForAndCondition(entity => entity.At <= BeforeAt);
                }
            }

            return entity => entity.Reception != null == HasReception;
        }
    }
}
