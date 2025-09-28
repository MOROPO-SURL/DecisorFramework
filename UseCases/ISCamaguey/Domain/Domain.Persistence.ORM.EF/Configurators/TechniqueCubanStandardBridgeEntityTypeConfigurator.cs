namespace MOROPO.ISCamaguey.Decisor.Domain.Persistence.ORM.EF.Configurators
{
    public class TechniqueCubanStandardBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.TechniqueCubanStandardBridge, Entities.Technique, System.Guid, Quality.Persistence.Entities.CubanStandard, int>
    {
        public TechniqueCubanStandardBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.CubanStandardBridge;
        }
    }
}
