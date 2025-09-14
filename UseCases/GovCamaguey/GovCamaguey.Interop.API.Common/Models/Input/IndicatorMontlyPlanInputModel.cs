namespace MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Input
{
    public class IndicatorMontlyPlanInputModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.IndicatorMontlyPlan, System.Guid>
    {
        public System.Guid Id { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }

        public double Amount { get; set; }

        public Persistence.Entities.IndicatorMontlyPlan Export()
        {
            var entity = new Persistence.Entities.IndicatorMontlyPlan { Id = Id };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.IndicatorMontlyPlan entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.IndicatorMontlyPlan entity)
        {
            entity.Month = Month;
            entity.Year = Year;
            entity.Amount = Amount;
        }
    }
}
