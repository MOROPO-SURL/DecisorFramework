namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities
{
    public class NaturalClientPropertySupervisionControlAction : Contract.AbstractSupervisionControlAction
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(LeasingId))]
        public NaturalClientPropertyLeasing Leasing { get; set; }
        public System.Guid LeasingId { get; set; }
    }
}
