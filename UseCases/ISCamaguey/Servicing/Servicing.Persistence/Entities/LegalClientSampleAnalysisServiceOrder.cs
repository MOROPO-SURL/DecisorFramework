namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities
{
    public class LegalClientSampleAnalysisServiceOrder : Contract.AbstractSampleAnalysisServiceOrder
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(SampleAnalysisLegalClientId))]
        public Framework.Decisor.Commercial.Persistence.Entities.LegalClient Client { get; set; }
        public System.Guid SampleAnalysisLegalClientId { get; set; }
    }
}
