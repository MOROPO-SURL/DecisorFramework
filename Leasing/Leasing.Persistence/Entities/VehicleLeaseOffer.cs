namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities
{
    public class VehicleLeaseOffer : Contract.AbstractLeaseOffer
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(PropousalId))]
        public VehicleLeasePropousal Propousal { get; set; }
        public System.Guid PropousalId { get; set; }

        public System.Collections.Generic.ICollection<VehicleLeaseOrganizationPostulation> OrganizationPostulations { get; set; }

        public System.Collections.Generic.ICollection<VehicleLeasePersonPostulation> PersonPostulations { get; set; }

        public System.Collections.Generic.List<VehicleLeaseOfferClauseBridge> ClauseBridges { get; set; }
    }
}