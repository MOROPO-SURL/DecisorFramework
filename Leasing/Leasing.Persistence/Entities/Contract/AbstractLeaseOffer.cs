namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities.Contract
{
    [System.ComponentModel.DataAnnotations.Schema.NotMapped]
    public abstract class AbstractLeaseOffer : Core.Persistence.Entities.Contract.IFullFeatureEntity<System.Guid>
    {
        public System.Guid Id { get; set; }

        public bool Archived { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        public System.DateTime At { get; set; } = System.DateTime.Now;

        public System.DateTime OpenAt { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(AgreementId))]
        public Governance.Persistence.Entities.Agreement Agreement { get; set; }
        public System.Guid AgreementId { get; set; }

        public System.DateTime? ClosedAt { get; set; }

        public System.DateTime? LeasedAt { get; set; }

        public decimal BaselineAmount { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(BaselineCurrencyId))]
        public Financial.Persistence.Entities.Currency BaselineCurrency { get; set; }
        public System.Guid BaselineCurrencyId { get; set; }

        public string Description { get; set; }
    }
}
