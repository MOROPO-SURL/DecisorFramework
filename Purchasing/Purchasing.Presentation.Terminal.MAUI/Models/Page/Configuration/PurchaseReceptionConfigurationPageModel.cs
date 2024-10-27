using System.Collections.ObjectModel;
using MOROPO.Framework.Decisor.Essential.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Inventory.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Display;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class PurchaseReceptionConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<PurchaseReceptionDisplayModel>
    {
        private PurchaseDisplayModel purchase;
        private EmployeeDisplayModel responsible;
        private string description;
        private WarehouseDisplayModel warehouse;

        public PurchaseReceptionConfigurationPageModel(PurchaseReceptionDisplayModel model) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                Purchase = model.Purchase;
                Responsible = model.Responsible;

                foreach (var item in model.WeightBridges) RegularWeights.Add(new View.PurchaseReceptionProductCommonWeightBridgeViewModel
                {
                    Product = item.Product,
                    Amount = item.Amount
                });
            }
        }

        public System.Guid Id { get; set; }

        public PurchaseDisplayModel Purchase { get => purchase; set => SetProperty(ref purchase, value); }

        public EmployeeDisplayModel Responsible { get => responsible; set => SetProperty(ref responsible, value); }

        public string Description { get => description; set => SetProperty(ref description, value); }

        public WarehouseDisplayModel Warehouse { get => warehouse; set => SetProperty(ref warehouse, value); }

        public ObservableCollection<View.PurchaseReceptionProductCommonWeightBridgeViewModel> RegularWeights { get; set; } = new ObservableCollection<View.PurchaseReceptionProductCommonWeightBridgeViewModel>();

        public ObservableCollection<View.PurchaseReceptionProductCommonWeightBridgeViewModel> ContextualWeights { get; set; } = new ObservableCollection<View.PurchaseReceptionProductCommonWeightBridgeViewModel>();

        public EmployeeDisplayModel[] AvailableResponsibles { get; set; }

        public WarehouseDisplayModel[] AvailableWarehouses { get; set; }
    } 
}
