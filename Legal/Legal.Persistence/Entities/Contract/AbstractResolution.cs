namespace MOROPO.Framework.Decisor.Legal.Persistence.Entities.Contract
{
    public abstract class AbstractResolution : Guama.Core.Persistence.Entities.Contract.IArchivableEntity<long>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public long Id { get; set; }

        public bool Archived { get; set; }

        public System.DateTime At { get; set;}

        [System.ComponentModel.DataAnnotations.Required]
        public string Summary { get; set; }
    }
}
