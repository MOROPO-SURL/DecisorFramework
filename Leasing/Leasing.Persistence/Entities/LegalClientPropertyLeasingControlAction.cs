namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities
{
    public class LegalClientPropertyLeasingControlAction : Contract.AbstractLeasingControlAction
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(LeasingId))]
        public LegalClientPropertyLeasing Leasing { get; set; }
        public System.Guid LeasingId { get; set; }
    }
}
