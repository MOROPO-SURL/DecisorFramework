namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities
{
    public class LegalClientPropertyLeasingCompensation : Contract.AbstractLeasingCompensation
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(LeasingId))]
        public LegalClientPropertyLeasing Leasing { get; set; }
        public System.Guid LeasingId { get; set; }

        public System.Collections.Generic.List<LegalClientPropertyLeasingCompensationDocumentBridge> DocumentBridges { get; set; } = new System.Collections.Generic.List<LegalClientPropertyLeasingCompensationDocumentBridge>();
    }
}
