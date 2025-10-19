using System.Collections.Generic;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Input
{
    public class TrainingServiceInputModel : Contract.AbstractServiceInputModel<Persistence.Entities.TrainingService>
    {
        public List<TrainingServiceStepInputModel> EditionSteps { get; set; } = new List<TrainingServiceStepInputModel>();
        public List<TrainingServiceStepInputModel> IncomingSteps { get; set; } = new List<TrainingServiceStepInputModel>();
        public List<Display.TrainingServiceStepDisplayModel> OutgoingSteps { get; set; } = new List<Display.TrainingServiceStepDisplayModel>();

        public override Persistence.Entities.TrainingService Export()
        {
            var entity = new Persistence.Entities.TrainingService { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }
    }
}
