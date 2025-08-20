namespace MOROPO.Framework.Decisor.Domain.Persistence.Entities
{
    public class Employee : Core.Persistence.Entities.Contract.IFullFeatureEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public bool Enabled { get; set; }

        public bool Archived { get; set; }

        public int Priority { get; set; }

        public System.DateTime At { get; set; } = System.DateTime.Now;

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ContactId))]
        public PersonContact Contact { get; set; }
        public System.Guid ContactId { get; set; }
    }
}
