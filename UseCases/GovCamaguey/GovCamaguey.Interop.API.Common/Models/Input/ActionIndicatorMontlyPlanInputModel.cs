namespace MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Input
{
    public class ActionIndicatorMontlyPlanInputModel : Contract.AbstractIndicatorMontlyPlanInputModel<Persistence.Entities.ActionIndicatorMontlyPlan>
    {
        public override Persistence.Entities.ActionIndicatorMontlyPlan Export()
        {
            var entity = new Persistence.Entities.ActionIndicatorMontlyPlan { Id = Id };

            Mergue(entity);

            return entity;
        }
    }
}