namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities
{
    public class NaturalClientPropertyLeasing : Contract.AbstractLeasing
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ContractId))]
        public NaturalClientPropertyLeaseContract Contract { get; set; }
        public System.Guid ContractId { get; set; }

        public System.Collections.Generic.List<NaturalClientPropertyLeasingPersonContactBridge> ContactBridges { get; set; } = new System.Collections.Generic.List<NaturalClientPropertyLeasingPersonContactBridge>();
    }
}
