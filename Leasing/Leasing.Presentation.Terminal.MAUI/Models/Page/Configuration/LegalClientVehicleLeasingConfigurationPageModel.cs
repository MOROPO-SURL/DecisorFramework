using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class LegalClientVehicleLeasingConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<LegalClientVehicleLeasingDisplayModel>
    {
        private string objective;
        private System.DateTime startAt = System.DateTime.Now;
        private VehicleLeaseOrganizationPostulationDisplayModel postulation;
        private Governance.Interop.API.Common.Models.Display.AgreementDisplayModel agreement;
        private string operativeLicenceCode;
        private double feed;
        private Legal.Persistence.Enumerations.DurationUnitMeasureKind feedDurationUnitMeasureKind;
        private Commercial.Interop.API.Common.Models.Display.PaymentTermDisplayModel paymentTerm;

        public LegalClientVehicleLeasingConfigurationPageModel(LegalClientVehicleLeasingDisplayModel model) : base(model)
        {
        }

        public System.Guid Id { get; set; }

        public string OperativeLicenceCode { get => operativeLicenceCode; set => SetProperty(ref operativeLicenceCode, value); }

        public string Objective { get => objective; set => SetProperty(ref objective, value); }

        public System.DateTime StartAt { get => startAt; set => SetProperty(ref startAt, value); }

        public Governance.Interop.API.Common.Models.Display.AgreementDisplayModel Agreement { get => agreement; set => SetProperty(ref agreement, value); }
        
        public VehicleLeaseOrganizationPostulationDisplayModel Postulation { get => postulation; set => SetProperty(ref postulation, value); }

        public double Feed { get => feed; set => SetProperty(ref feed, value); }

        public Legal.Persistence.Enumerations.DurationUnitMeasureKind FeedDurationUnitMeasureKind { get => feedDurationUnitMeasureKind; set => SetProperty(ref feedDurationUnitMeasureKind, value); }

        public Commercial.Interop.API.Common.Models.Display.PaymentTermDisplayModel PaymentTerm { get => paymentTerm; set => SetProperty(ref paymentTerm, value); }

        public System.Collections.ObjectModel.ObservableCollection<Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel> Contacts { get; set; } = [];
    }
}
