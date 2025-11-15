namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.ORM.EF.Configurators
{
    public class ServicingContractGroundIntegralStudyServiceBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.ServicingContractGroundIntegralStudyServiceBridge, Entities.Contract.AbstractServicingContract, int, Entities.GroundIntegralStudyService, System.Guid>
    {
        public ServicingContractGroundIntegralStudyServiceBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.GroundIntegralStudyServiceBridges;
        }
    }
}