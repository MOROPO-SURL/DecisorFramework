namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities
{
    public class ServicingContractTrainingServiceBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<Contract.AbstractServicingContract, int, TrainingService, System.Guid>
    {
        public int ProwId { get; set; }
        public Contract.AbstractServicingContract Prow { get; set; }

        public System.Guid SternId { get; set; }
        public TrainingService Stern { get; set; }
    }
}
