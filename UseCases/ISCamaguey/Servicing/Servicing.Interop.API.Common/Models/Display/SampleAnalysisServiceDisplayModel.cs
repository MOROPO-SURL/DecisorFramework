namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Display
{
    public class SampleAnalysisServiceDisplayModel : Contract.AbstractServiceDisplayModel<Persistence.Entities.SampleAnalysisService>
    {
        public SampleAnalysisServiceStepDisplayModel[] Steps { get; set; }
    }
}
