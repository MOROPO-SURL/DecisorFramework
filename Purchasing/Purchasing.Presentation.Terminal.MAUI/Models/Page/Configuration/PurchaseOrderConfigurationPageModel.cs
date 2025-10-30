using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Financial.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Bridge;
using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Display;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class PurchaseOrderConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<PurchaseOrderDisplayModel>
    {
        public static string AgreementValidableProperty => nameof(Agreement);
        public static string ResponsibleValidableProperty => nameof(Responsible);
        public static string ZoneValidableProperty => nameof(Zone);
        public static string PlannedForValidableProperty => nameof(PlannedFor);
        public static string ResultProductBridgesForValidableProperty => nameof(ResultProductBridges);
        public static string AdvanceRequiredForValidableProperty => nameof(AdvanceRequired);
        public static string AdvanceRequiredCurrencyForValidableProperty => nameof(AdvanceRequiredCurrency);

        private System.DateTime plannedFor = System.DateTime.Now;
        private string description;
        private int priority = 1;
        private Governance.Interop.API.Common.Models.Display.AgreementDisplayModel agreement;
        private PurchaseRequestDisplayModel request;
        private EmployeeDisplayModel responsible;
        private PurchaseZoneDisplayModel zone;
        private bool hasAdvanceRequired;
        private float estimatedAdvance;
        private CurrencyDisplayModel advanceRequiredCurrency;

        public PurchaseOrderConfigurationPageModel(PurchaseOrderDisplayModel model = null) : base(model)
        {
            if (model == null) return;
            
            Id = model.Id;
            plannedFor = model.PlannedFor;
            description = model.Description;
            priority = model.Priority;
            agreement = model.Agreement;
            request = model.Request;
            responsible = model.Responsible;
            zone = model.Zone;
            hasAdvanceRequired = model.AdvanceRequired != null;
            estimatedAdvance = model.AdvanceRequired ?? 0;
            advanceRequiredCurrency = model.AdvanceRequiredCurrency;
            LegalProviderBridges = [.. model.LegalProviderBridges];
            NaturalProviderBridges = [.. model.NaturalProviderBridges];
            ResultProductBridges = [.. model.ResultProductBridges];
            SpentProductBridges = [.. model.SpentProductBridges];
        }

        public System.Guid Id { get; set; }

        public System.DateTime PlannedFor { get => plannedFor; set => SetProperty(ref plannedFor, value); }

        public string Description { get => description; set => SetProperty(ref description, value); }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public PurchaseRequestDisplayModel Request { get => request; set => SetProperty(ref request, value); }

        public EmployeeDisplayModel Responsible { get => responsible; set => SetProperty(ref responsible, value); }

        public PurchaseZoneDisplayModel Zone { get => zone; set => SetProperty(ref zone, value); }

        public bool HasAdvanceRequired { get => hasAdvanceRequired; set => SetProperty(ref hasAdvanceRequired, value); }

        public float AdvanceRequired { get => estimatedAdvance; set => SetProperty(ref estimatedAdvance, value); }

        public CurrencyDisplayModel AdvanceRequiredCurrency { get => advanceRequiredCurrency; set => SetProperty(ref advanceRequiredCurrency, value); }

        public Governance.Interop.API.Common.Models.Display.AgreementDisplayModel Agreement { get => agreement; set => SetProperty(ref agreement, value); }

        public System.Collections.ObjectModel.ObservableCollection<PurchaseOrderLegalProviderBridgeModel> LegalProviderBridges { get; set; } = [];

        public System.Collections.ObjectModel.ObservableCollection<PurchaseOrderNaturalProviderBridgeModel> NaturalProviderBridges { get; set; } = [];

        public System.Collections.ObjectModel.ObservableCollection<PurchaseCommonProductBridgeModel> ResultProductBridges { get; set; } = [];

        public System.Collections.ObjectModel.ObservableCollection<PurchaseCommonProductBridgeModel> SpentProductBridges { get; set; } = [];

        public PurchaseZoneDisplayModel[] AvailableZones { get; set; }

        public CurrencyDisplayModel[] AvailableCurrencies { get; set; }
    }
}
