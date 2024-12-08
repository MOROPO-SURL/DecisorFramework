using System.Collections.ObjectModel;
using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Bridge;
using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.Models.View;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class PurchaseConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<PurchaseDisplayModel>
    {
        private PurchasePlanDisplayModel plan;
        private PurchaseZoneDisplayModel zone;
        private EmployeeDisplayModel purchaser;
        private string description;

        public PurchaseConfigurationPageModel(PurchaseDisplayModel model = null) : base(model)
        {
            //if (model != null)
            //{
            //    Id = model.Id;
            //    Description = model.Description;
            //    Zone = model.Zone;
            //    Purchaser = model.Purchaser;

            //    foreach (var item in model.LegalProviderProductBridges) LegalProviderProductBridges.Add(item);

            //    foreach (var item in model.NaturalProviderProductBridges) NaturalProviderProductBridges.Add(item);

            //    foreach (var item in model.EmployeeBridges) EmployeeBridges.Add(item);

            //    foreach (var item in model.ColaboratorBridges) ColaboratorBridges.Add(item);

            //    RegularSpentBridges = new ObservableCollection<PurchasePurchaseSpentBridgeModel>(model.SpentBridges.Where(_model => _model.));
            //}
        }

        public System.Guid Id { get; set; }

        public string Description { get => description; set => SetProperty(ref description, value); }

        public PurchasePlanDisplayModel Plan { get => plan; set => SetProperty(ref plan, value); }

        public PurchaseZoneDisplayModel Zone { get => zone; set => SetProperty(ref zone, value); }

        public EmployeeDisplayModel Purchaser { get => purchaser; set => SetProperty(ref purchaser, value); }

        public ObservableCollection<PurchaseProductLegalProviderBridgeModel> LegalProviderProductBridges { get; set; } = new ObservableCollection<PurchaseProductLegalProviderBridgeModel>();

        public ObservableCollection<PurchaseProductNaturalProviderBridgeModel> NaturalProviderProductBridges { get; set; } = new ObservableCollection<PurchaseProductNaturalProviderBridgeModel>();

        public ObservableCollection<PurchasePurchaseSpentBridgeViewModel> RegularSpentBridges { get; set; } = new ObservableCollection<PurchasePurchaseSpentBridgeViewModel>();

        public ObservableCollection<PurchasePurchaseSpentBridgeViewModel> ExtraSpentBridges { get; set; } = new ObservableCollection<PurchasePurchaseSpentBridgeViewModel>();

        public ObservableCollection<PurchaseEmployeeBridgeModel> EmployeeBridges { get; set; } = new ObservableCollection<PurchaseEmployeeBridgeModel>();

        public ObservableCollection<PurchaseColaboratorBridgeModel> ColaboratorBridges { get; set; } = new ObservableCollection<PurchaseColaboratorBridgeModel>();

        public PurchaseZoneDisplayModel[] AvailableZones { get; set; }

        public EmployeeDisplayModel[] AvailablePurchasers { get; set; }

        public Financial.Interop.API.Common.Models.Display.CostCenterDisplayModel[] AvailableCostCenters { get; set; }
    }
}
