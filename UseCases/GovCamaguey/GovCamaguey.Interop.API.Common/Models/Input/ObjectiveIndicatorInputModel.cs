using System.Collections.Generic;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Input
{
    public class ObjectiveIndicatorInputModel : Contract.AbstractIndicatorInputModel<Persistence.Entities.ObjectiveIndicator>
    {
        public List<ObjectiveIndicatorMontlyPlanInputModel> EditionMontlyPlans { get; set; } = new List<ObjectiveIndicatorMontlyPlanInputModel>();
        public List<ObjectiveIndicatorMontlyPlanInputModel> IncomingMontlyPlans { get; set; } = new List<ObjectiveIndicatorMontlyPlanInputModel>();
        public List<Display.ObjectiveIndicatorMontlyPlanDisplayModel> OutgoingMontlyPlans { get; set; } = new List<Display.ObjectiveIndicatorMontlyPlanDisplayModel>();

        public override Persistence.Entities.ObjectiveIndicator Export()
        {
            var entity = new Persistence.Entities.ObjectiveIndicator { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }
    }
}
