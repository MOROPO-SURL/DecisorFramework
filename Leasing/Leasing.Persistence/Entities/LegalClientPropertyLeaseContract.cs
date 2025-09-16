namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities
{
    public class LegalClientPropertyLeaseContract : Contract.AbstractLeaseContract
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(PostulationId))]
        public PropertyLeaseOrganizationPostulation Postulation { get; set; }
        public System.Guid PostulationId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ClientId))]
        public Commercial.Persistence.Entities.LegalClient Client { get; set; }
        public System.Guid ClientId { get; set; }

        public System.Collections.Generic.List<LegalClientPropertyLeaseContractSpaceBridge> SpaceBridges { get; set; } = new System.Collections.Generic.List<LegalClientPropertyLeaseContractSpaceBridge>();
    }
}
