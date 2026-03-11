namespace MOROPO.Framework.Decisor.Legal.Persistence.Entities.Contract
{
    public abstract class AbstractResolution : Guama.Core.Persistence.Entities.Contract.IArchivableEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        public bool Archived { get; set; }

        public int Index { get; set; }

        public int Year { get; set; }

        public System.DateTime At { get; set;}

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MaxLength(2048)]
        public string Summary { get; set; }
    }
}
