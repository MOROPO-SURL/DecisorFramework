namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities
{
    public class LegalClientSampleAnalysisServiceOrder : Contract.AbstractSampleAnalysisServiceOrder
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(SampleAnalysisLegalClientContractId))]
        public LegalClientServicingContract Contract { get; set; }
        public System.Guid SampleAnalysisLegalClientContractId { get; set; }
    }
}
