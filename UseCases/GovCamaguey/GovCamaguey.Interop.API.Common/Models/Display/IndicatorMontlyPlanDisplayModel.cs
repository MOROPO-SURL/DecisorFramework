namespace MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Display
{
    public class IndicatorMontlyPlanDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.IndicatorMontlyPlan, System.Guid>
    {
        public System.Guid Id { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }

        public double Amount { get; set; }

        public void Import(Persistence.Entities.IndicatorMontlyPlan entity)
        {
            Id = entity.Id;
            Month = entity.Month;
            Year = entity.Year;
            Amount = entity.Amount;
        }

        public override string ToString()
        {
            return $"{Constants.Globals.MONTHS[Month - 1]} / {Year} => {Amount:F2}";
        }
    }
}
