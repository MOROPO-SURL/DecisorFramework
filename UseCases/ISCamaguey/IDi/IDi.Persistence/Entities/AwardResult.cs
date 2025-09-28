namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class AwardResult : Contract.AbstractResult
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(KindId))]
        public AwardKind Kind { get; set; } 
        public System.Guid KindId { get; set; }
    }
}
