using System.Collections.ObjectModel;

namespace MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class ProductionConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.ProductionDisplayModel>
    {
        public static string OrderValidableProperty => nameof(Order);
        public static string AmountValidableProperty => nameof(Amount);
        public static string UnitMeasurementValidableProperty => nameof(UnitMeasurement);
        public static string AtValidableProperty => nameof(At);

        private Interop.API.Common.Models.Display.ProductionOrderDisplayModel order;
        private decimal amount;
        private Domain.Interop.API.Common.Models.Display.UnitMeasurementDisplayModel unitMeasurement;
        private System.DateTime at = System.DateTime.Now;
        private string description;

        public ProductionConfigurationPageModel(Interop.API.Common.Models.Display.ProductionDisplayModel model = null) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                order = model.Order;
                amount = model.Amount;
                unitMeasurement = model.UnitMeasurement;
                at = model.At;
                description = model.Description;

                foreach (var item in model.ProductBridges) ProductBridges.Add(new View.ProductionProductBridgeViewModel { Product = item.Product, Amount = item.Amount, UnitMeasurement = item.UnitMeasurement });

                foreach (var item in model.EmployeeBridges) EmployeeBridges.Add(item);

                foreach (var item in model.ColaboratorBridges) ColaboratorBridges.Add(item);
            }
        }

        public System.Guid Id { get; set; }

        public string Description { get => description; set => SetProperty(ref description, value); }

        public Interop.API.Common.Models.Display.ProductionOrderDisplayModel Order { get => order; set => SetProperty(ref order, value); }

        public decimal Amount { get => amount; set => SetProperty(ref amount, value); }

        public System.DateTime At { get => at; set => SetProperty(ref at, value); }

        public Domain.Interop.API.Common.Models.Display.UnitMeasurementDisplayModel UnitMeasurement { get => unitMeasurement; set => SetProperty(ref unitMeasurement, value); }

        public ObservableCollection<View.ProductionProductBridgeViewModel> ProductBridges { get; set; } = [];

        public ObservableCollection<Interop.API.Common.Models.Bridge.ProductionEmployeeBridgeModel> EmployeeBridges { get; set; } = [];

        public ObservableCollection<Interop.API.Common.Models.Bridge.ProductionColaboratorBridgeModel> ColaboratorBridges { get; set; } = [];

        public ObservableCollection<Domain.Interop.API.Common.Models.Display.UnitMeasurementDisplayModel> AvailableUnitMeasurements { get; set; } = [];
    }
}