namespace MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Input
{
    public class ProyectionIndicatorMontlyPlanInputModel : Contract.AbstractIndicatorMontlyPlanInputModel<Persistence.Entities.ProyectionIndicatorMontlyPlan>
    {
        public override Persistence.Entities.ProyectionIndicatorMontlyPlan Export()
        {
            var entity = new Persistence.Entities.ProyectionIndicatorMontlyPlan { Id = Id };

            Mergue(entity);

            return entity;
        }
    }
}