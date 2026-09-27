namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities.Contract
{
    public abstract class AbstractSampleAnalysisServiceOrder : AbstractServiceOrder
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(SampleAnalysisServiceId))]
        public SampleAnalysisService Service { get; set; }
        public System.Guid SampleAnalysisServiceId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(RequestedTechniqueId))]
        public Domain.Persistence.Entities.Technique RequestedTechnique { get; set; }
        public System.Guid? RequestedTechniqueId { get; set;}

        public System.DateTime? SampleReceptionAt { get; set; }

        public System.DateTime? HandledAt { get; set; }
    }
}
