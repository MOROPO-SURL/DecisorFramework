namespace MOROPO.Framework.Decisor.Financial.Persistence.Entities.Contract
{
    public abstract class AbstractCollect : Guama.Core.Persistence.Entities.Contract.IArchivableEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        public bool Archived { get; set; }

        public System.DateTime At { get; set; } = System.DateTime.Now;

        public System.DateTime ExpectedAt { get; set; }

        public float Amount { get; set; }

        public string Description { get; set; }
    }
}
