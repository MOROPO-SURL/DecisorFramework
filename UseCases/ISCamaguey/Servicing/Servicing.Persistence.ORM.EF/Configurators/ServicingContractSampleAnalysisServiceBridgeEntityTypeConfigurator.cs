namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.ORM.EF.Configurators
{
    public class ServicingContractSampleAnalysisServiceBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.ServicingContractSampleAnalysisServiceBridge, Entities.Contract.AbstractServicingContract, int, Entities.SampleAnalysisService, System.Guid>
    {
        public ServicingContractSampleAnalysisServiceBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.SampleAnalysisServiceBridges;
        }
    }
}
