namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities
{
    public class ServicingContractGroundIntegralStudyServiceBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<Contract.AbstractServicingContract, System.Guid, GroundIntegralStudyService, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public Contract.AbstractServicingContract Prow { get; set; }

        public System.Guid SternId { get; set; }
        public GroundIntegralStudyService Stern { get; set; }
    }
}
