namespace MOROPO.Framework.Decisor.Legal.Persistence.ORM.EF.Configurators
{
    public class ClauseTagBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.ClauseTagBridge, Entities.Clause, System.Guid, Entities.Tag, string>
    {
        public ClauseTagBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.TagBridges;
        }
    }
}
