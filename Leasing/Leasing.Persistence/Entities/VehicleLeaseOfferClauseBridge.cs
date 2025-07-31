namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities
{
    public class VehicleLeaseOfferClauseBridge : Guama.Core.Persistence.Entities.Contract.IBridge<VehicleLeaseOffer, System.Guid, Legal.Persistence.Entities.Clause, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public VehicleLeaseOffer Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Legal.Persistence.Entities.Clause Stern { get; set; }
    }
}
