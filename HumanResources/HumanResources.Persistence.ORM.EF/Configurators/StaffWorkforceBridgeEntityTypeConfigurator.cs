using MOROPO.Framework.Decisor.HumanResources.Persistence.Entities;

namespace MOROPO.Framework.Decisor.HumanResources.Persistence.ORM.EF.Configurators
{
    public class StaffWorkforceBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<StaffWorkforceBridge, Staff, System.Guid, Workforce, System.Guid>
    {
        public StaffWorkforceBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.AlternativeWorkforceBridges;
        }
    }
}
