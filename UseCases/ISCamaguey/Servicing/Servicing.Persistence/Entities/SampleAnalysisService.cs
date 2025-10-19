namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities
{
    public class SampleAnalysisService : Contract.AbstractService
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(SampleKindId))]
        public Domain.Persistence.Entities.SampleKind SampleKind { get; set; }
        public System.Guid SampleKindId { get; set; }

        public System.Collections.ObjectModel.Collection<SampleAnalysisServiceStep> Steps { get; set; }
    }
}
