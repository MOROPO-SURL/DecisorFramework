namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities
{
    public class NaturalClientPropertyLeasingControlAction : Contract.AbstractLeasingControlAction
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(LeasingId))]
        public NaturalClientPropertyLeasing Leasing { get; set; }
        public System.Guid LeasingId { get; set; }
    }
}
