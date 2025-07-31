namespace MOROPO.Framework.Decisor.Governance.Persistence.ORM.EF.Configurators
{
    public class MeetingEmployeeBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.MeetingEmployeeBridge, Entities.Meeting, System.Guid, HumanResources.Persistence.Entities.Employee, System.Guid>
    {
        public MeetingEmployeeBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.EmployeeBridges;
        }
    }
}