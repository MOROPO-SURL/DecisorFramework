namespace MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Filter
{
    public class PurchasePlanFilterModel : Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.PurchasePlan, System.Guid>
    {
        public Enumerations.CommonPlanFilterKind Kind { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.PurchasePlan, bool>> GetSelector()
        {
            switch (Kind) 
            {
                case Enumerations.CommonPlanFilterKind.Filled:

                    return entity => entity.Purchase != null;
                
                case Enumerations.CommonPlanFilterKind.ToApprove:

                    return entity => entity.ApprovedAt == null;

                case Enumerations.CommonPlanFilterKind.ToComplete:
                default:

                    return entity => entity.ApprovedAt != null && entity.Purchase == null;
            }
        }
    }
}
