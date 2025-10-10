namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities
{
    public class NaturalClientPropertyLeaseContract : Contract.AbstractLeaseContract
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(PropertyLeaseNaturalPostulationId))]
        public PropertyLeasePersonPostulation Postulation { get; set; }
        public System.Guid? PropertyLeaseNaturalPostulationId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(PropertyLeaseNaturalClientId))]
        public Commercial.Persistence.Entities.NaturalClient Client { get; set; }
        public System.Guid? PropertyLeaseNaturalClientId { get; set; }

        public System.Collections.Generic.List<NaturalClientPropertyLeaseContractSpaceBridge> SpaceBridges { get; set; } = new System.Collections.Generic.List<NaturalClientPropertyLeaseContractSpaceBridge>();
    }
}
