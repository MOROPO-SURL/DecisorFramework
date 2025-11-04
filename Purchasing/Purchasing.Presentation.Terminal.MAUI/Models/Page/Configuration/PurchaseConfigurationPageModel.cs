using System.Collections.ObjectModel;
using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Bridge;
using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.Models.View;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class PurchaseConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<PurchaseDisplayModel>
    {
        public static string PurchaserValidableProperty => nameof(Purchaser);
        public static string OrderValidableProperty => nameof(Order);
        public static string LegalProviderProductBridgesValidableProperty => nameof(LegalProviderProductBridges);
        public static string NaturalProviderProductBridgesValidableProperty => nameof(NaturalProviderProductBridges);

        private PurchaseOrderDisplayModel order;
        private Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel purchaser;
        private Financial.Interop.API.Common.Models.Display.CostCenterDisplayModel costCenter;
        private string description;

        public PurchaseConfigurationPageModel(PurchaseDisplayModel model = null) : base(model)
        {
        }

        public System.Guid Id { get; set; }

        public string Description { get => description; set => SetProperty(ref description, value); }

        public PurchaseOrderDisplayModel Order { get => order; set => SetProperty(ref order, value); }

        public Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel Purchaser { get => purchaser; set => SetProperty(ref purchaser, value); }

        public ObservableCollection<PurchaseProductLegalProviderBridgeModel> LegalProviderProductBridges { get; set; } = [];

        public ObservableCollection<PurchaseProductNaturalProviderBridgeModel> NaturalProviderProductBridges { get; set; } = [];

        public ObservableCollection<PurchasePurchaseSpentBridgeViewModel> RegularSpentBridges { get; set; } = [];

        public ObservableCollection<PurchasePurchaseSpentBridgeViewModel> ExtraSpentBridges { get; set; } = [];

        public ObservableCollection<PurchaseEmployeeBridgeModel> EmployeeBridges { get; set; } = [];

        public ObservableCollection<PurchaseColaboratorBridgeModel> ColaboratorBridges { get; set; } = [];

        public Financial.Interop.API.Common.Models.Display.CostCenterDisplayModel[] AvailableCostCenters { get; set; }
    }
}
