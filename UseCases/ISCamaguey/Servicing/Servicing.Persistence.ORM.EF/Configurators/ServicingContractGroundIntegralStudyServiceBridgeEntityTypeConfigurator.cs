namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.ORM.EF.Configurators
{
    public class ServicingContractGroundIntegralStudyServiceBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.ServicingContractGroundIntegralStudyServiceBridge, Entities.Contract.AbstractServicingContract, System.Guid, Entities.GroundIntegralStudyService, System.Guid>
    {
        public ServicingContractGroundIntegralStudyServiceBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.GroundIntegralStudyServiceBridges;
        }
    }
}