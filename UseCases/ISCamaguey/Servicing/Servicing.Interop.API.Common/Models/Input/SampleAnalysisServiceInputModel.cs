using System.Collections.Generic;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Input
{
    public class SampleAnalysisServiceInputModel : Contract.AbstractServiceInputModel<Persistence.Entities.SampleAnalysisService>
    {
        public List<SampleAnalysisServiceStepInputModel> EditionSteps { get; set; } = new List<SampleAnalysisServiceStepInputModel>();
        public List<SampleAnalysisServiceStepInputModel> IncomingSteps { get; set; } = new List<SampleAnalysisServiceStepInputModel>();
        public List<Display.SampleAnalysisServiceStepDisplayModel> OutgoingSteps { get; set; } = new List<Display.SampleAnalysisServiceStepDisplayModel>();

        public override Persistence.Entities.SampleAnalysisService Export()
        {
            var entity = new Persistence.Entities.SampleAnalysisService { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }
    }
}
