namespace MOROPO.Framework.Decisor.Commercial.Persistence.Entities.Contract
{
    public abstract class AbstractNaturalRelationship : Core.Persistence.Entities.Contract.IFullFeatureEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public bool Enabled { get; set; }

        public bool Archived { get; set; }

        public int Priority { get; set; }

        public System.DateTime At { get; set; } = System.DateTime.Now;

        public NaturalContact Contact { get; set; }
        public System.Guid ContactId { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.RegularExpression("^[0-9]{11}$")]
        public string PersonalIdentificationNumber { get; set; }
    }
}

