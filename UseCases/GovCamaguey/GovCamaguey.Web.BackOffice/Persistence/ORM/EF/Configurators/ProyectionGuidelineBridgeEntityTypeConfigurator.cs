using MOROPO.GovCamaguey.Decisor.Prototype.Persistence.Entities;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Web.BackOffice.Persistence.ORM.EF.Configurators
{
    public class ProyectionGuidelineBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<ProyectionGuidelineBridge, Proyection, System.Guid, Guideline, System.Guid>
    {
        public ProyectionGuidelineBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = bridge => bridge.GuidelineBridges;
        }
    }
}
