namespace MOROPO.ISCamaguey.Decisor.Quality.Persistence.ORM.EF.Configurators
{
    public class CertificationCubanStandardBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.CertificationCubanStandardBridge, Entities.Certification, System.Guid, Entities.CubanStandard, int>
    {
        public CertificationCubanStandardBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.CubanStandardBridges;
        }
    }
}
