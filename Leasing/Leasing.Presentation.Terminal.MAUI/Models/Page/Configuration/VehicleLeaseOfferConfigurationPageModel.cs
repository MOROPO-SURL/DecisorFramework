using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class VehicleLeaseOfferConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<VehicleLeaseOfferDisplayModel>
    {
        public static string PropousalValidableProperty => nameof(Propousal);
        public static string AgreementValidableProperty => nameof(Agreement);
        public static string DescriptionValidableProperty => nameof(Description);
        public static string BaselineAmountValidableProperty => nameof(BaselineAmount);
        public static string BaselineCurrencyValidableProperty => nameof(BaselineCurrency);

        private int priority = 1;
        private System.DateTime openAt = System.DateTime.Now;
        private System.DateTime closedAt = System.DateTime.Now;
        private bool hasClosetAtDate;
        private string description;
        private VehicleLeasePropousalDisplayModel propousal;
        private Governance.Interop.API.Common.Models.Display.AgreementDisplayModel agreement;
        private decimal baselineAmount;
        private Financial.Interop.API.Common.Models.Display.CurrencyDisplayModel baselineCurrency;

        public VehicleLeaseOfferConfigurationPageModel(VehicleLeaseOfferDisplayModel model) : base(model)
        {
            if (model == null) return;

            Id = model.Id;
            Priority = model.Priority;
            OpenAt = model.OpenAt;
            ClosedAt = model.ClosedAt ?? System.DateTime.Now;
            hasClosetAtDate = model.ClosedAt != null;
            Description = model.Description;
            Propousal = model.Propousal;
            Agreement = model.Agreement;
            baselineAmount = model.BaselineAmount;
            baselineCurrency = model.BaselineCurrency;
        }

        public System.Guid Id { get; set; }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public System.DateTime OpenAt { get => openAt; set => SetProperty(ref openAt, value); }

        public System.DateTime ClosedAt { get => closedAt; set => SetProperty(ref closedAt, value); }

        public bool HasClosetAtDate { get => hasClosetAtDate; set => SetProperty(ref hasClosetAtDate, value); }

        public string Description { get => description; set => SetProperty(ref description, value); }

        public VehicleLeasePropousalDisplayModel Propousal { get => propousal; set => SetProperty(ref propousal, value); }

        public Governance.Interop.API.Common.Models.Display.AgreementDisplayModel Agreement { get => agreement; set => SetProperty(ref agreement, value); }

        public decimal BaselineAmount { get => baselineAmount; set => SetProperty(ref baselineAmount, value); }

        public Financial.Interop.API.Common.Models.Display.CurrencyDisplayModel BaselineCurrency { get => baselineCurrency; set => SetProperty(ref baselineCurrency, value); }

        public Financial.Interop.API.Common.Models.Display.CurrencyDisplayModel[] AvailableCurrencies { get; set; }
    }
}
