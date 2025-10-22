namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities
{
    public class SampleAnalysisService : Contract.AbstractService
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(SampleKindId))]
        public Domain.Persistence.Entities.SampleKind SampleKind { get; set; }
        public System.Guid SampleKindId { get; set; }

        public System.Collections.Generic.ICollection<SampleAnalysisServiceStep> Steps { get; set; }

        public System.Collections.Generic.List<SampleAnalysisServiceEmployeeBridge> EmployeeBridges { get; set; } = new System.Collections.Generic.List<SampleAnalysisServiceEmployeeBridge>();

        public System.Collections.Generic.List<SampleAnalysisServiceDocumentBridge> DocumentBridges { get; set; } = new System.Collections.Generic.List<SampleAnalysisServiceDocumentBridge>();
    }
}
