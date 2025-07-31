namespace MOROPO.Framework.Decisor.Governance.Persistence.Entities
{
    public class MeetingEmployeeBridge : Guama.Core.Persistence.Entities.Contract.IBridge<Meeting, System.Guid, HumanResources.Persistence.Entities.Employee, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public Meeting Prow { get; set; }

        public System.Guid SternId { get; set; }
        public HumanResources.Persistence.Entities.Employee Stern { get; set; }
    }
}
