namespace MOROPO.Framework.Decisor.Governance.Persistence.Entities
{
    public class Agreement : Guama.Core.Persistence.Entities.Contract.IEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(MeetingId))]
        public Meeting Meeting { get; set; }
        public System.Guid MeetingId { get; set; }

        public int Index { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public System.DateTime? EndAt { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ResponsibleId))]
        public Domain.Persistence.Entities.PersonContact Responsible { get; set; }
        public System.Guid? ResponsibleId { get; set; }
    }
}
