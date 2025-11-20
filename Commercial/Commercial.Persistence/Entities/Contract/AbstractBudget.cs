namespace MOROPO.Framework.Decisor.Commercial.Persistence.Entities.Contract
{
    [System.ComponentModel.DataAnnotations.Schema.NotMapped]
    public abstract class AbstractBudget : Guama.Core.Persistence.Entities.Contract.IArchivableEntity<System.Guid>, Guama.Core.Persistence.Entities.Contract.IEnableableEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        public bool Enabled { get; set; }

        public bool Archived { get; set; }

        public int Number { get; set; }

        public int Year { get; set; }

        public System.DateTime At { get; set; } = System.DateTime.Now;

        public System.DateTime? SharedAt { get; set; }

        public System.DateTime? ConfirmedAt { get; set; }

        public string Description { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(CommercialId))]
        public Domain.Persistence.Entities.Employee Commercial { get; set; }
        public System.Guid CommercialId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(DocumentId))]
        public Guama.Media.Persistence.Entities.Document Document { get; set; }
        public System.Guid? DocumentId { get; set; }
    }
}

