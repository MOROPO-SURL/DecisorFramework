namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Display
{
    public class SampleAnalysisServiceStepDisplayModel : Contract.AbstractServiceStepDisplayModel<Persistence.Entities.SampleAnalysisServiceStep>
    {
        public SampleAnalysisServiceStepDisplayModel[] Children { get; set; }
    }
}
