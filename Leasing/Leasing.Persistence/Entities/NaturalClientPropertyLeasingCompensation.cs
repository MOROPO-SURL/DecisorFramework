namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities
{
    public class NaturalClientPropertyLeasingCompensation : Contract.AbstractLeasingCompensation
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(LeasingId))]
        public NaturalClientPropertyLeasing Leasing { get; set; }
        public System.Guid LeasingId { get; set; }

        public System.Collections.Generic.List<NaturalClientPropertyLeasingCompensationDocumentBridge> DocumentBridges { get; set; } = new System.Collections.Generic.List<NaturalClientPropertyLeasingCompensationDocumentBridge>();
    }
}
