using System.Collections.Generic;
using System.Linq;

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

        public override void Mergue(Persistence.Entities.TrainingService entity)
        {
            base.Mergue(entity);

            

            entity.EmployeeBridges.Clear();

            entity.EmployeeBridges = Members.Select(model => new Persistence.Entities.TrainingServiceEmployeeBridge
            {
                ProwId = entity.Id,
                SternId = model.Id
            }).ToList();
        }
    }
}
