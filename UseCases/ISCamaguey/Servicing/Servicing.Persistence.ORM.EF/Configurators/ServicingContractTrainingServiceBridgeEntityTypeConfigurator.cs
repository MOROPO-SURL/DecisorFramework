namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.ORM.EF.Configurators
{
    public class ServicingContractTrainingServiceBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.ServicingContractTrainingServiceBridge, Entities.Contract.AbstractServicingContract, System.Guid, Entities.TrainingService, System.Guid>
    {
        public ServicingContractTrainingServiceBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.TrainingServiceBridges;
        }
    }
}