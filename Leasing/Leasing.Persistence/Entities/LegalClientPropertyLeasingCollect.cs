namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities
{
    public class LegalClientPropertyLeasingCollect : Financial.Persistence.Entities.Contract.AbstractCollect
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(LegalClientPropertyLeasingId))]
        public LegalClientPropertyLeasing Leasing { get; set; }
        public System.Guid LegalClientPropertyLeasingId { get; set; }
    }
}
