namespace MOROPO.Framework.Decisor.Legal.Persistence.ORM.EF.Configurators
{
    public class DispositionTagBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.DispositionTagBridge, Entities.Disposition, System.Guid, Entities.Tag, string>
    {
        public DispositionTagBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.TagBridges;
        }
    }
}
