using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class NaturalClientVehicleLeasingConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<NaturalClientVehicleLeasingDisplayModel>
    {
        public static string ObjectiveValidableProperty => nameof(Objective);
        public static string AgreementValidableProperty => nameof(Agreement);
        public static string OperativeLicenceCodeValidableProperty => nameof(OperativeLicenceCode);
        public static string DurationUnitCountValidableProperty => nameof(DurationUnitCount);
        public static string DurationUnitMeasureKindValidableProperty => nameof(DurationUnitMeasureKind);
        public static string FeedValidableProperty => nameof(Feed);
        public static string PaymentTermValidableProperty => nameof(PaymentTerm);

        private int priority = 1;
        private int index = 1;
        private string objective;
        private System.DateTime startAt = System.DateTime.Now;
        private Governance.Interop.API.Common.Models.Display.AgreementDisplayModel agreement;
        private string operativeLicenceCode;
        private int durationUnitCount = 1;
        private Legal.Persistence.Enumerations.DurationUnitMeasureKind durationUnitMeasureKind;
        private double feed;
        private Commercial.Interop.API.Common.Models.Display.PaymentTermDisplayModel paymentTerm;

        public NaturalClientVehicleLeasingConfigurationPageModel(VehicleLeasePersonPostulationDisplayModel postulation, NaturalClientVehicleLeasingDisplayModel model) : base(model)
        {
            Postulation = postulation;
        }

        public System.Guid Id { get; set; }

        public VehicleLeasePersonPostulationDisplayModel Postulation { get; set; }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public string OperativeLicenceCode { get => operativeLicenceCode; set => SetProperty(ref operativeLicenceCode, value); }

        public int Index { get => index; set => SetProperty(ref index, value); }

        public string Objective { get => objective; set => SetProperty(ref objective, value); }

        public System.DateTime StartAt { get => startAt; set => SetProperty(ref startAt, value); }

        public Governance.Interop.API.Common.Models.Display.AgreementDisplayModel Agreement { get => agreement; set => SetProperty(ref agreement, value); }

        public int DurationUnitCount { get => durationUnitCount; set => SetProperty(ref durationUnitCount, value); }

        public Legal.Persistence.Enumerations.DurationUnitMeasureKind DurationUnitMeasureKind { get => durationUnitMeasureKind; set => SetProperty(ref durationUnitMeasureKind, value); }

        public double Feed { get => feed; set => SetProperty(ref feed, value); }

        public Commercial.Interop.API.Common.Models.Display.PaymentTermDisplayModel PaymentTerm { get => paymentTerm; set => SetProperty(ref paymentTerm, value); }

        public System.Collections.ObjectModel.ObservableCollection<Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel> Contacts { get; set; } = [];

        public Legal.Persistence.Enumerations.DurationUnitMeasureKind[] AvailableDurationUnitMeasureKinds { get; } = [Legal.Persistence.Enumerations.DurationUnitMeasureKind.Years, Legal.Persistence.Enumerations.DurationUnitMeasureKind.Months, Legal.Persistence.Enumerations.DurationUnitMeasureKind.Days, Legal.Persistence.Enumerations.DurationUnitMeasureKind.Hours];

        public Commercial.Interop.API.Common.Models.Display.PaymentTermDisplayModel[] AvailablePaymentTerms { get; set; } = [];
    }
}
