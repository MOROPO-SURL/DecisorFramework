namespace MOROPO.Framework.Decisor.Commercial.Persistence.ORM.EF.Configurators
{
    public class ProductValuePropositionImageBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.ProductValuePropositionImageBridge, Entities.ProductValueProposition, System.Guid, Guama.Media.Persistence.Entities.Image, System.Guid>
    {
        public ProductValuePropositionImageBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.ImageBridges;
        }
    }
}
