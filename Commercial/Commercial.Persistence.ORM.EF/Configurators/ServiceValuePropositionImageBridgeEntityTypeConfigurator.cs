namespace MOROPO.Framework.Decisor.Commercial.Persistence.ORM.EF.Configurators
{
    public class ServiceValuePropositionImageBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.ServiceValuePropositionImageBridge, Entities.ServiceValueProposition, System.Guid, Guama.Media.Persistence.Entities.Image, System.Guid>
    {
        public ServiceValuePropositionImageBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.ImageBridges;
        }
    }
}