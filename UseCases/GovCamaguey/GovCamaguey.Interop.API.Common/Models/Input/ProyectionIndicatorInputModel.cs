using System.Collections.Generic;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Input
{
    public class ProyectionIndicatorInputModel : Contract.AbstractIndicatorInputModel<Persistence.Entities.ProyectionIndicator>
    {
        public List<ProyectionIndicatorMontlyPlanInputModel> EditionMontlyPlans { get; set; } = new List<ProyectionIndicatorMontlyPlanInputModel>();
        public List<ProyectionIndicatorMontlyPlanInputModel> IncomingMontlyPlans { get; set; } = new List<ProyectionIndicatorMontlyPlanInputModel>();
        public List<Display.ProyectionIndicatorMontlyPlanDisplayModel> OutgoingMontlyPlans { get; set; } = new List<Display.ProyectionIndicatorMontlyPlanDisplayModel>();

        public override Persistence.Entities.ProyectionIndicator Export()
        {
            var entity = new Persistence.Entities.ProyectionIndicator { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }
    }
}
