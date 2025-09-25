namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities
{
    public class NaturalClientPropertyLeasingCollect : Financial.Persistence.Entities.Contract.AbstractCollect
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(NaturalClientPropertyLeasingId))]
        public NaturalClientPropertyLeasing Leasing { get; set; }
        public System.Guid NaturalClientPropertyLeasingId { get; set; }
    }
}
