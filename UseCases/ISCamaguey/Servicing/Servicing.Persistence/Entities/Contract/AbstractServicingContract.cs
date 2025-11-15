namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities.Contract
{
    public abstract class AbstractServicingContract : Framework.Decisor.Legal.Persistence.Entities.Contract.AbstractContract
    {
        public double Feed { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(PaymentTermId))]
        public Framework.Decisor.Commercial.Persistence.Entities.PaymentTerm PaymentTerm { get; set; }
        public System.Guid PaymentTermId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(BankAccountId))]
        public Framework.Decisor.Financial.Persistence.Entities.BankAccount BankAccount { get; set; }
        public System.Guid BankAccountId { get; set; }

        public System.Collections.Generic.List<ServicingContractTrainingServiceBridge> TrainingServiceBridges { get; set; } = new System.Collections.Generic.List<ServicingContractTrainingServiceBridge>();

        public System.Collections.Generic.List<ServicingContractGroundIntegralStudyServiceBridge> GroundIntegralStudyServiceBridges { get; set; } = new System.Collections.Generic.List<ServicingContractGroundIntegralStudyServiceBridge>();

        public System.Collections.Generic.List<ServicingContractSampleAnalysisServiceBridge> SampleAnalysisServiceBridges { get; set; } = new System.Collections.Generic.List<ServicingContractSampleAnalysisServiceBridge>();
    }
}