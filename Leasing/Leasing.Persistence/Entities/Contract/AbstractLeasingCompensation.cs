namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities.Contract
{
    [System.ComponentModel.DataAnnotations.Schema.NotMapped]
    public abstract class AbstractLeasingCompensation : Guama.Core.Persistence.Entities.Contract.IEntity<System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(AgreementId))]
        public Governance.Persistence.Entities.Agreement Agreement { get; set; }
        public System.Guid AgreementId { get; set; }

        public System.DateTime StartAt { get; set; }

        public System.DateTime EndAt { get; set; }

        public double DiscountFraction { get; set; }

        public string Description { get; set; }
    }
}
