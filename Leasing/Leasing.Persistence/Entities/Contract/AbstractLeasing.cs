namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities.Contract
{
    [System.ComponentModel.DataAnnotations.Schema.NotMapped]
    public abstract class AbstractLeasing : Guama.Core.Persistence.Entities.Contract.IArchivableEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        public bool Archived { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(AgreementId))]
        public Governance.Persistence.Entities.Agreement Agreement { get; set; }
        public System.Guid AgreementId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(CostCenterId))]
        public Financial.Persistence.Entities.CostCenter CostCenter { get; set; }
        public System.Guid CostCenterId { get; set; }
    }
}
