namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities
{
    public class LegalClientPropertyLeaseContract : Contract.AbstractLeaseContract
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(PropertyLeaseLegalPostulationId))]
        public PropertyLeaseOrganizationPostulation Postulation { get; set; }
        public System.Guid? PropertyLeaseLegalPostulationId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(PropertyLeaseLegalClientId))]
        public Commercial.Persistence.Entities.LegalClient Client { get; set; }
        public System.Guid? PropertyLeaseLegalClientId { get; set; }

        public System.Collections.Generic.List<LegalClientPropertyLeaseContractSpaceBridge> SpaceBridges { get; set; } = new System.Collections.Generic.List<LegalClientPropertyLeaseContractSpaceBridge>();
    }
}
