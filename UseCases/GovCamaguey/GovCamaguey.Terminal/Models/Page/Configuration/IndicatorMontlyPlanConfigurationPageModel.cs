using System.Collections.Generic;
using System.Linq;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.Models.Page.Configuration
{
    public class IndicatorMontlyPlanConfigurationPageModel : Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Input.IndicatorMontlyPlanInputModel>
    {
        public static string YearMonthValidableProperty => nameof(YearMonth);
        public static string AmountValidableProperty => nameof(Amount);

        private KeyValuePair<int, int> yearMonthPair;
        private double amount;

        public IndicatorMontlyPlanConfigurationPageModel(Interop.API.Common.Models.Display.UnitMeasurementDisplayModel unitMeasurement, KeyValuePair<int, int>[] availableYearMonthPairs, Interop.API.Common.Models.Input.IndicatorMontlyPlanInputModel model) : base(model)
        {
            UnitMeasurement = unitMeasurement;
            AvailableYearMonthPairs = availableYearMonthPairs;

            if (model != null)
            {
                Id = model.Id;
                yearMonthPair = availableYearMonthPairs.First(item => item.Key == model.Year && item.Value == model.Month);
                Amount = model.Amount;
            }
        }

        public System.Guid Id { get; set; }

        public Interop.API.Common.Models.Display.UnitMeasurementDisplayModel UnitMeasurement { get; set; }

        public KeyValuePair<int, int> YearMonth { get => yearMonthPair; set => SetProperty(ref yearMonthPair, value); }

        public double Amount { get => amount; set => SetProperty(ref amount, value); }

        public KeyValuePair<int, int>[] AvailableYearMonthPairs { get; private set; }
    }
}