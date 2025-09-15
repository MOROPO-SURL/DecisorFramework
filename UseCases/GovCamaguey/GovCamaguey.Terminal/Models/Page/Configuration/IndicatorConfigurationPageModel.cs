using System.Collections.ObjectModel;
using System.Linq;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.Models.Page.Configuration
{
    public class IndicatorConfigurationPageModel : Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Input.IndicatorInputModel>
    {
        public static string NameValidableProperty => nameof(Name);
        public static string AmountValidableProperty => nameof(Amount);

        private string name;
        private string description;
        private int priority = 1;
        private double amount;

        public IndicatorConfigurationPageModel() : this(null) { }

        public IndicatorConfigurationPageModel(Interop.API.Common.Models.Input.IndicatorInputModel model, Interop.API.Common.Models.Display.IndicatorMontlyPlanDisplayModel[] montlyPlans = null) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                Priority = model.Priority;
                Name = model.Name;
                Description = model.Description;
                Amount = model.Amount;
                UnitMeasurementId = model.UnitMeasurementId;

                if (montlyPlans != null)
                {
                    MontlyPlans = new ObservableCollection<Interop.API.Common.Models.Display.IndicatorMontlyPlanDisplayModel>(montlyPlans.OrderBy(_model => _model.Year * 100 + _model.Month));
                }
            }
        }

        public System.Guid Id { get; set; }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public string Name { get => name; set => SetProperty(ref name, value); }

        public string Description { get => description; set => SetProperty(ref description, value); }

        public double Amount { get => amount; set => SetProperty(ref amount, value); }

        public System.Guid? UnitMeasurementId { get; set; }

        public ObservableCollection<Interop.API.Common.Models.Display.IndicatorMontlyPlanDisplayModel> MontlyPlans { get; set; } = [];

        public Interop.API.Common.Models.Display.UnitMeasurementDisplayModel[] AvailableUnitMeasurements { get; set; }
    }
}
