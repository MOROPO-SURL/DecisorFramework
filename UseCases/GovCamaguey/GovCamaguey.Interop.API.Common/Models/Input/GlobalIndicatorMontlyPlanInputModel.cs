namespace MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Input
{
    public class GlobalIndicatorMontlyPlanInputModel : Contract.AbstractIndicatorMontlyPlanInputModel<Persistence.Entities.GlobalIndicatorMontlyPlan>
    {
        public override Persistence.Entities.GlobalIndicatorMontlyPlan Export()
        {
            var entity = new Persistence.Entities.GlobalIndicatorMontlyPlan { Id = Id };

            Mergue(entity);

            return entity;
        }
    }
}
