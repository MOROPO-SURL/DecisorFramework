namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities
{
    public class NaturalClientSampleAnalysisServiceOrder : Contract.AbstractSampleAnalysisServiceOrder
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(SampleAnalysisNaturalClientContractId))]
        public NaturalClientServicingContract Contract { get; set; }
        public System.Guid SampleAnalysisNaturalClientContractId { get; set; }
    }
}
