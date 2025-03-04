using MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Display;
using System.Collections.ObjectModel;

namespace MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class ProductionConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<ProductionDisplayModel>
    {
        // TODO Resposible?? !!!!!
        private ProductionOrderDisplayModel order;
        private decimal amount;
        private Inventory.Interop.API.Common.Models.Display.UnitMeasurementDisplayModel unitMeasurement;
        private string description;

        public ProductionConfigurationPageModel(ProductionDisplayModel model = null) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                Description = model.Description;

                foreach (var item in model.ProductBridges) ProductBridges.Add(new View.ProductionProductBridgeViewModel { Product = item.Product, Amount = item.Amount, UnitMeasurement = item.UnitMeasurement });

                foreach (var item in model.EmployeeBridges) EmployeeBridges.Add(item);

                foreach (var item in model.ColaboratorBridges) ColaboratorBridges.Add(item);
            }
        }

        public System.Guid Id { get; set; }

        public string Description { get => description; set => SetProperty(ref description, value); }

        public ProductionOrderDisplayModel Order { get => order; set => SetProperty(ref order, value); }

        public decimal Amount { get => amount; set => SetProperty(ref amount, value); }

        public Inventory.Interop.API.Common.Models.Display.UnitMeasurementDisplayModel UnitMeasurement { get => unitMeasurement; set => SetProperty(ref unitMeasurement, value); }

        public ObservableCollection<View.ProductionProductBridgeViewModel> ProductBridges { get; set; } = [];

        public ObservableCollection<Interop.API.Common.Models.Bridge.ProductionEmployeeBridgeModel> EmployeeBridges { get; set; } = [];

        public ObservableCollection<Interop.API.Common.Models.Bridge.ProductionColaboratorBridgeModel> ColaboratorBridges { get; set; } = [];

        public Inventory.Interop.API.Common.Models.Display.UnitMeasurementDisplayModel[] AvailableUnitMeasurements { get; set; } = [];
    }
}
