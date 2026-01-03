using System.Linq;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Display
{
    public class ProyectionIndicatorDisplayModel : Contract.AbstractIndicatorDisplayModel<Persistence.Entities.ProyectionIndicator>
    {
        public ProyectionIndicatorMontlyPlanDisplayModel[] MontlyPlans { get; set; }

        public override void Import(Persistence.Entities.ProyectionIndicator entity)
        {
            base.Import(entity);

            MontlyPlans = entity.MontlyPlans.OrderBy(_model => _model.Year * 100 + _model.Month).Select(_entity =>
            {
                var model = new ProyectionIndicatorMontlyPlanDisplayModel();

                model.Import(_entity);

                return model;
            }).ToArray();
        }
    }
}
