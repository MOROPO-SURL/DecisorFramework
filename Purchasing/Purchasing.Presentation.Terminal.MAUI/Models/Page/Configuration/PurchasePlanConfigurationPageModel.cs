using System.Collections.ObjectModel;
using MOROPO.Framework.Decisor.Essential.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Bridge;
using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Display;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class PurchasePlanConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<PurchasePlanDisplayModel>
    {
        private System.DateTime plannedFor;
        private string description;
        private int priority = 1;
        private PurchaseZoneDisplayModel zone;
        private EmployeeDisplayModel planner;
        private EmployeeDisplayModel responsible;
        private EmployeeDisplayModel decisor;

        public PurchasePlanConfigurationPageModel(PurchasePlanDisplayModel model = null) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                PlannedFor = model.PlannedFor;
                Description = model.Description;
                Priority = model.Priority;
                Zone = model.Zone;
                Planner = model.Planner;
                Responsible = model.Responsible;
                Decisor = model.Decisor;

                foreach (var item in model.LegalProviderBridges) LegalProviderBridges.Add(item);

                foreach (var item in model.NaturalProviderBridges) NaturalProviderBridges.Add(item);

                foreach (var item in model.InputProductBridges) InputProductBridges.Add(item);

                foreach (var item in model.OutputProductBridges) OutputProductBridges.Add(item);
            }
            else
            {
                PlannedFor = System.DateTime.Now;
            }
        }

        public System.Guid Id { get; set; }

        public System.DateTime PlannerForMinDate { get; } = System.DateTime.Now;

        public System.DateTime PlannedFor { get => plannedFor; set => SetProperty(ref plannedFor, value); }

        public string Description { get => description; set => SetProperty(ref description, value); }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public PurchaseZoneDisplayModel Zone { get => zone; set => SetProperty(ref zone, value); }

        public EmployeeDisplayModel Planner { get => planner; set => SetProperty(ref planner, value); }

        public EmployeeDisplayModel Responsible { get => responsible; set => SetProperty(ref responsible, value); }

        public EmployeeDisplayModel Decisor { get => decisor; set => SetProperty(ref decisor, value); }

        public ObservableCollection<PurchasePlanLegalProviderBridgeModel> LegalProviderBridges { get; set; } = new ObservableCollection<PurchasePlanLegalProviderBridgeModel>();

        public ObservableCollection<PurchasePlanNaturalProviderBridgeModel> NaturalProviderBridges { get; set; } = new ObservableCollection<PurchasePlanNaturalProviderBridgeModel>();

        public ObservableCollection<PurchasePlanCommonProductBridgeModel> InputProductBridges { get; set; } = new ObservableCollection<PurchasePlanCommonProductBridgeModel>();

        public ObservableCollection<PurchasePlanCommonProductBridgeModel> OutputProductBridges { get; set; } = new ObservableCollection<PurchasePlanCommonProductBridgeModel>();

        public PurchaseZoneDisplayModel[] AvailableZones { get; set; }

        public EmployeeDisplayModel[] AvailablePlanners { get; set; }

        public EmployeeDisplayModel[] AvailableResponsibles { get; set; }

        public EmployeeDisplayModel[] AvailableDecisors { get; set; }
    }
}
