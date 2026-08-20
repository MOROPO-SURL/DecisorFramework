namespace MOROPO.Framework.Decisor.HumanResources.Persistence.Entities
{
    public class RemotionResolution : Legal.Persistence.Entities.Contract.AbstractResolution
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(OcupationId))]
        public Ocupation Ocupation { get; set; }
        public System.Guid OcupationId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(AgreementId))]
        public Governance.Persistence.Entities.Agreement Agreement { get; set; }
        public System.Guid? AgreementId { get; set; }

        public System.DateTime? ConcretedAt { get; set; }
    }
}