namespace MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities
{
    public class SampleReceptionLabel : Framework.Guama.Core.Persistence.Entities.Contract.IEnableableEntity<System.Guid>, Framework.Guama.Core.Persistence.Entities.Contract.IPriorizableEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Reference { get; set; }

        public Contract.AbstractSample Sample { get; set; }
    }
}
