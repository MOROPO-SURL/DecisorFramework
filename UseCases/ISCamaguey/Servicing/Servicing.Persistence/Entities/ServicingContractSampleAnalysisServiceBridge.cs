namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities
{
    public class ServicingContractSampleAnalysisServiceBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<Contract.AbstractServicingContract, int, SampleAnalysisService, System.Guid>
    {
        public int ProwId { get; set; }
        public Contract.AbstractServicingContract Prow { get; set; }

        public System.Guid SternId { get; set; }
        public SampleAnalysisService Stern { get; set; }
    }
}
