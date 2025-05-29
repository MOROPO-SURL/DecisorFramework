namespace MOROPO.Framework.Decisor.Production.Persistence.Entities
{
    public class VehicleLeaseOffer : Contract.AbstractLeaseOffer
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(VehicleId))]
        public Domain.Persistence.Entities.Vehicle Vehicle { get; set; }
        public System.Guid VehicleId { get; set; }

        public System.Collections.Generic.ICollection<VehicleLeaseOrganizationPostulation> OrganizationPostulations { get; set; }

        public System.Collections.Generic.ICollection<VehicleLeasePersonPostulation> PersonPostulations { get; set; }

        public System.Collections.Generic.List<VehicleLeaseOfferClauseBridge> ClauseBridges { get; set; }
    }
}