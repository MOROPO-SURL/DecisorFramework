using System.Collections.ObjectModel;
using System.Linq;
using MOROPO.Framework.Decisor.Inventory.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display;
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

                var universe = model.WeightBridges.GroupBy(_model => _model.CostCenter);

                foreach (var item in universe) Weights.Add(new View.PurchaseReceptionWeightsByCostCenterViewModel
                {
                    CostCenter = item.Key,
                    ProductWeights = item.Select(_model => new View.PurchaseReceptionProductWeightBridgeViewModel
                    {
                        Product = _model.Product,
                        Amount = _model.Amount
                    }).ToArray()
                });
            }
        }

        public System.Guid Id { get; set; }

        public PurchaseDisplayModel Purchase { get => purchase; set => SetProperty(ref purchase, value); }

        public EmployeeDisplayModel Responsible { get => responsible; set => SetProperty(ref responsible, value); }

        public string Description { get => description; set => SetProperty(ref description, value); }

        public WarehouseDisplayModel Warehouse { get => warehouse; set => SetProperty(ref warehouse, value); }

        public ObservableCollection<Models.View.PurchaseReceptionWeightsByCostCenterViewModel> Weights { get; set; } = new ObservableCollection<Models.View.PurchaseReceptionWeightsByCostCenterViewModel>();

        public EmployeeDisplayModel[] AvailableResponsibles { get; set; }

        public WarehouseDisplayModel[] AvailableWarehouses { get; set; }
    } 
}
