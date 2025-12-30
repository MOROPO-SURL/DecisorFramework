using System.Collections.Generic;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Input
{
    public class ActionIndicatorInputModel : Contract.AbstractIndicatorInputModel<Persistence.Entities.ActionIndicator>
    {
        public List<ActionIndicatorMontlyPlanInputModel> EditionMontlyPlans { get; set; } = new List<ActionIndicatorMontlyPlanInputModel>();
        public List<ActionIndicatorMontlyPlanInputModel> IncomingMontlyPlans { get; set; } = new List<ActionIndicatorMontlyPlanInputModel>();
        public List<Display.ActionIndicatorMontlyPlanDisplayModel> OutgoingMontlyPlans { get; set; } = new List<Display.ActionIndicatorMontlyPlanDisplayModel>();

        public override Persistence.Entities.ActionIndicator Export()
        {
            var entity = new Persistence.Entities.ActionIndicator { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }
    }
}
