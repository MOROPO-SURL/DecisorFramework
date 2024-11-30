namespace MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Filter
{
    public class ProductionPlanFilterModel : Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.ProductionPlan, System.Guid>
    {
        public Core.Interop.API.Common.Enumerations.CommonPlanFilterKind Kind { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.ProductionPlan, bool>> GetSelector()
        {
            switch (Kind)
            {
                case Core.Interop.API.Common.Enumerations.CommonPlanFilterKind.Filled:

                    return entity => entity.Production != null;

                case Core.Interop.API.Common.Enumerations.CommonPlanFilterKind.ToApprove:

                    return entity => entity.ApprovedAt == null;

                case Core.Interop.API.Common.Enumerations.CommonPlanFilterKind.ToComplete:
                default:

                    return entity => entity.ApprovedAt != null && entity.Production == null;
            }
        }
    }
}
