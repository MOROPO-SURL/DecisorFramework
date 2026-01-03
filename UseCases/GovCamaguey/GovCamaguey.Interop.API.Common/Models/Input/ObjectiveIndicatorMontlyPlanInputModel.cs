namespace MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Input
{
    public class ObjectiveIndicatorMontlyPlanInputModel : Contract.AbstractIndicatorMontlyPlanInputModel<Persistence.Entities.ObjectiveIndicatorMontlyPlan>
    {
        public override Persistence.Entities.ObjectiveIndicatorMontlyPlan Export()
        {
            var entity = new Persistence.Entities.ObjectiveIndicatorMontlyPlan { Id = Id };

            Mergue(entity);

            return entity;
        }
    }
}