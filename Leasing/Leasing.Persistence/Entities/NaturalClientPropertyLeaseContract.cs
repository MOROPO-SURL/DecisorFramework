namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities
{
    public class NaturalClientPropertyLeaseContract : Contract.AbstractPropertyLeaseContract
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(PostulationId))]
        public PropertyLeasePersonPostulation Postulation { get; set; }
        public System.Guid PostulationId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ClientId))]
        public Commercial.Persistence.Entities.NaturalClient Client { get; set; }
        public System.Guid ClientId { get; set; }

        public System.Collections.Generic.List<NaturalClientPropertyLeaseContractSpaceBridge> SpaceBridges { get; set; } = new System.Collections.Generic.List<NaturalClientPropertyLeaseContractSpaceBridge>();
    }
}
