namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities
{
    public class NaturalClientSampleAnalysisServiceOrder : Contract.AbstractSampleAnalysisServiceOrder
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(SampleAnalysisNaturalClientId))]
        public Framework.Decisor.Commercial.Persistence.Entities.NaturalClient Client { get; set; }
        public System.Guid SampleAnalysisNaturalClientId { get; set; }
    }
}
