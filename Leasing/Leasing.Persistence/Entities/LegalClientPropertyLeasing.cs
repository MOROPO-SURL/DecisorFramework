namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities
{
    public class LegalClientPropertyLeasing : Contract.AbstractLeasing
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ContractId))]
        public LegalClientPropertyLeaseContract Contract { get; set; }
        public int ContractId { get; set; }

        public System.Collections.Generic.List<LegalClientPropertyLeasingPersonContactBridge> ContactBridges { get; set; } = new System.Collections.Generic.List<LegalClientPropertyLeasingPersonContactBridge>();
    }
}