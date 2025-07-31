namespace MOROPO.Framework.Decisor.Governance.Persistence.Entities
{
    public class MeetingContactBridge : Guama.Core.Persistence.Entities.Contract.IBridge<Meeting, System.Guid, Domain.Persistence.Entities.PersonContact, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public Meeting Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Domain.Persistence.Entities.PersonContact Stern { get; set; }
    }
}
