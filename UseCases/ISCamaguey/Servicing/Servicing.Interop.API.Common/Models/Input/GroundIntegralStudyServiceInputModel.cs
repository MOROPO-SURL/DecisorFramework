using System.Collections.Generic;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Input
{
    public class GroundIntegralStudyServiceInputModel : Contract.AbstractServiceInputModel<Persistence.Entities.GroundIntegralStudyService>
    {
        public List<GroundIntegralStudyServiceStepInputModel> EditionSteps { get; set; } = new List<GroundIntegralStudyServiceStepInputModel>();
        public List<GroundIntegralStudyServiceStepInputModel> IncomingSteps { get; set; } = new List<GroundIntegralStudyServiceStepInputModel>();
        public List<Display.GroundIntegralStudyServiceStepDisplayModel> OutgoingSteps { get; set; } = new List<Display.GroundIntegralStudyServiceStepDisplayModel>();

        public override Persistence.Entities.GroundIntegralStudyService Export()
        {
            var entity = new Persistence.Entities.GroundIntegralStudyService { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Persistence.Entities.GroundIntegralStudyService entity)
        {
            base.Mergue(entity);



            entity.EmployeeBridges.Clear();

            entity.EmployeeBridges = Members.Select(model => new Persistence.Entities.GroundIntegralStudyServiceEmployeeBridge
            {
                ProwId = entity.Id,
                SternId = model.Id
            }).ToList();
        }
    }
}
