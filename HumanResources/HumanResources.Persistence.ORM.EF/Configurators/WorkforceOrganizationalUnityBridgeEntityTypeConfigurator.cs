namespace MOROPO.Framework.Decisor.HumanResources.Persistence.ORM.EF.Configurators
{
    public class WorkforceOrganizationalUnityBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.WorkforceOrganizationalUnityBridge, Entities.Workforce, System.Guid, Domain.Persistence.Entities.OrganizationalUnity, System.Guid>
    {
        public WorkforceOrganizationalUnityBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.OrganizationalUnityBridges;
        }
    }
}