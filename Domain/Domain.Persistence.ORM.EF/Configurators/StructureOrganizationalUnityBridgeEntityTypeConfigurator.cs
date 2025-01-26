namespace MOROPO.Framework.Decisor.Domain.Persistence.ORM.EF.Configurators
{
    public class StructureOrganizationalUnityBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.StructureOrganizationalUnityBridge, Entities.Structure, System.Guid, Entities.OrganizationalUnity, System.Guid>
    {
        public StructureOrganizationalUnityBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.OrganizationalUnityBridges;
        }
    }
}
