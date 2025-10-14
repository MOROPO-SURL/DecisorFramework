namespace MOROPO.ISCamaguey.Decisor.Domain.Persistence.ORM.EF.Configurators
{
    public class TechniqueIsoStandardBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.TechniqueIsoStandardBridge, Entities.Technique, System.Guid, Quality.Persistence.Entities.IsoStandard, System.Guid>
    {
        public TechniqueIsoStandardBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.IsoStandardBridge;
        }
    }
}