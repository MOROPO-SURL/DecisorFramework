namespace MOROPO.Framework.Decisor.HumanResources.Persistence.Entities.Contract
{
    public abstract class AbstractIncorporationResolution : Legal.Persistence.Entities.Contract.AbstractResolution
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(AgreementId))]
        public Governance.Persistence.Entities.Agreement Agreement { get; set; }
        public System.Guid? AgreementId { get; set; }

        public System.DateTime? ConcretedAt { get; set; }
    }
}