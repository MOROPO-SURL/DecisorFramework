namespace MOROPO.ISCamaguey.Decisor.Quality.Persistence.ORM.EF.Configurators
{
    public class CertificationIsoStandardBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.CertificationIsoStandardBridge, Entities.Certification, System.Guid, Entities.IsoStandard, int>
    {
        public CertificationIsoStandardBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.IsoStandardBridges;
        }
    }
}
