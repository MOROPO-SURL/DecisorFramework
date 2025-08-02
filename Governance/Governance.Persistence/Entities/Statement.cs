namespace MOROPO.Framework.Decisor.Governance.Persistence.Entities
{
    public class Statement : Guama.Core.Persistence.Entities.Contract.IEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(MeetingId))]
        public Meeting Meeting { get; set; }
        public System.Guid MeetingId { get; set; }

        public string Rapporteurship { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ContactId))]
        public Domain.Persistence.Entities.PersonContact Contact { get; set; }
        public System.Guid? ContactId { get; set; }
    }
}
