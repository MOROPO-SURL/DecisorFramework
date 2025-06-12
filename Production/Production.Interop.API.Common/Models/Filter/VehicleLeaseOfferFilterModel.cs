namespace MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Filter
{
    public class VehicleLeaseOfferFilterModel : Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.VehicleLeaseOffer, System.Guid>
    {
        public Core.Interop.API.Common.Enumerations.CommonPlanFilterKind Kind { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.VehicleLeaseOffer, bool>> GetSelector()
        {
            switch (Kind)
            {
                case Core.Interop.API.Common.Enumerations.CommonPlanFilterKind.Handled:

                    return entity => entity.DecisorId != null;

                case Core.Interop.API.Common.Enumerations.CommonPlanFilterKind.ToApprove:

                    return entity => entity.DecisorId == null;

                case Core.Interop.API.Common.Enumerations.CommonPlanFilterKind.ToComplete:
                default:

                    //return entity => entity.Production == null;
                    return entity => true;
            }
        }
    }
}
