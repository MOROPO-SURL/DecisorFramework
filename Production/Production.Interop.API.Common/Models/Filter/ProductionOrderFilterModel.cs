namespace MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Filter
{
    public class ProductionOrderFilterModel : Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.ProductionOrder, System.Guid>
    {
        public Core.Interop.API.Common.Enumerations.CommonPlanFilterKind Kind { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.ProductionOrder, bool>> GetSelector()
        {
            switch (Kind)
            {
                case Core.Interop.API.Common.Enumerations.CommonPlanFilterKind.Handled:

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
