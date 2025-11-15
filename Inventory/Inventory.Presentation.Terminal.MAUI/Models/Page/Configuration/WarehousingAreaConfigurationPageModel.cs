namespace MOROPO.Framework.Decisor.Inventory.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class WarehousingAreaConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.WarehousingAreaDisplayModel>
    {
        private string name;
        private double capacity;
        private Domain.Interop.API.Common.Models.Display.UnitMeasurementDisplayModel unitMeasurement;
        private string description;
        private Interop.API.Common.Models.Display.FamilyDisplayModel family;

        public WarehousingAreaConfigurationPageModel(Interop.API.Common.Models.Display.WarehousingAreaDisplayModel model) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                Name = model.Name;
                Capacity = model.Capacity;
                UnitMeasurement = model.UnitMeasurement;
                Description = model.Description;
                Family = model.Family;
            }
        }

        public System.Guid Id { get; set; }

        public string Name { get => name; set => SetProperty(ref name, value); }

        public double Capacity { get => capacity; set => SetProperty(ref capacity, value); }

        public Domain.Interop.API.Common.Models.Display.UnitMeasurementDisplayModel UnitMeasurement { get => unitMeasurement; set => SetProperty(ref unitMeasurement, value); }

        public string Description { get => description; set => SetProperty(ref description, value); }

        public Interop.API.Common.Models.Display.FamilyDisplayModel Family { get => family; set => SetProperty(ref family, value); }

        public Domain.Interop.API.Common.Models.Display.UnitMeasurementDisplayModel[] AvailableUnitMeasurements { get; set; }

        public Interop.API.Common.Models.Display.FamilyDisplayModel[] AvailableFamilies { get; set; }
    }
}
