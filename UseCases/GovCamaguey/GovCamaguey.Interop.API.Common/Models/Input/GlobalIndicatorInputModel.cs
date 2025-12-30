using System.Collections.Generic;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Input
{
    public class GlobalIndicatorInputModel : Contract.AbstractIndicatorInputModel<Persistence.Entities.GlobalIndicator>
    {
        public List<GlobalIndicatorMontlyPlanInputModel> EditionMontlyPlans { get; set; } = new List<GlobalIndicatorMontlyPlanInputModel>();
        public List<GlobalIndicatorMontlyPlanInputModel> IncomingMontlyPlans { get; set; } = new List<GlobalIndicatorMontlyPlanInputModel>();
        public List<Display.GlobalIndicatorMontlyPlanDisplayModel> OutgoingMontlyPlans { get; set; } = new List<Display.GlobalIndicatorMontlyPlanDisplayModel>();

        public override Persistence.Entities.GlobalIndicator Export()
        {
            var entity = new Persistence.Entities.GlobalIndicator { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }
    }
}
