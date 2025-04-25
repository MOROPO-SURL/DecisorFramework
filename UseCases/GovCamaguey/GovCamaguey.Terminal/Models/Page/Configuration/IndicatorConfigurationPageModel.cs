namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.Models.Page.Configuration
{
    public class IndicatorConfigurationPageModel : Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.IndicatorDisplayModel>
    {
        private string name;
        private string description;
        private int priority = 1;
        private double amount;

        public IndicatorConfigurationPageModel() : this(null) { }

        public IndicatorConfigurationPageModel(Interop.API.Common.Models.Display.IndicatorDisplayModel model) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                Priority = model.Priority;
                Name = model.Name;
                Description = model.Description;
                Amount = model.Amount;
                UnitMeasurementId = model.UnitMeasurement.Id;
            }
        }

        public System.Guid Id { get; set; }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public string Name { get => name; set => SetProperty(ref name, value); }

        public string Description { get => description; set => SetProperty(ref description, value); }

        public double Amount { get => amount; set => SetProperty(ref amount, value); }

        public System.Guid? UnitMeasurementId { get; set; }

        public Interop.API.Common.Models.Display.UnitMeasurementDisplayModel[] AvailableUnitMeasurements { get; set; }
    }
}
