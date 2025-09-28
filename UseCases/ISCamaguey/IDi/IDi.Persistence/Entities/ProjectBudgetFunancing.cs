namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class ProjectBudgetFunancing : Framework.Guama.Core.Persistence.Entities.Contract.IArchivableEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        public bool Archived { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(FinancierId))]
        public Financier Financier { get; set; }
        public System.Guid FinancierId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(FinancierId))]
        public Framework.Decisor.Financial.Persistence.Entities.Currency Currency { get; set; }
        public System.Guid CurrencyId { get; set; }

        public float Amount { get; set; }
    }
}
