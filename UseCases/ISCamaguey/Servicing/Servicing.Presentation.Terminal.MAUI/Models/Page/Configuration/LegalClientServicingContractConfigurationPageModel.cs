namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class LegalClientServicingContractConfigurationPageModel : Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.LegalClientServicingContractDisplayModel>
    {
        public static string IdValidableProperty => nameof(Id);
        public static string YearValidableProperty => nameof(Year);
        public static string ObjectiveValidableProperty => nameof(Objective);
        public static string DurationUnitCountValidableProperty => nameof(DurationUnitCount);
        public static string DurationUnitMeasureKindValidableProperty => nameof(DurationUnitMeasureKind);
        public static string PaymentTermValidableProperty => nameof(PaymentTerm);
        public static string ClientValidableProperty => nameof(Client);
        public static string BanckAccountValidableProperty => nameof(BanckAccount);
        public static string TrainingServicesValidableProperty => nameof(TrainingServices);
        public static string SampleAnalysisServicesValidableProperty => nameof(SampleAnalysisServices);
        public static string GroundIntegralStudyServicesValidableProperty => nameof(GroundIntegralStudyServices);

        private int id;
        private int year;
        private string objective;
        private System.DateTime startAt = System.DateTime.Now;
        private int durationUnitCount = 1;
        private Framework.Decisor.Legal.Persistence.Enumerations.DurationUnitMeasureKind durationUnitMeasureKind;
        private Framework.Decisor.Commercial.Interop.API.Common.Models.Display.PaymentTermDisplayModel paymentTerm;
        private Framework.Decisor.Commercial.Interop.API.Common.Models.Display.LegalClientDisplayModel client;
        private Framework.Decisor.Financial.Interop.API.Common.Models.Display.BankAccountDisplayModel bankAccount;

        public LegalClientServicingContractConfigurationPageModel(Interop.API.Common.Models.Display.LegalClientServicingContractDisplayModel model) : base(model)
        {
            if (model == null)
            {
                year = startAt.Year;

                return;
            }

            id = model.Id;
            year = model.Year;
            objective = model.Objective;
            startAt = model.StarAt;
            durationUnitCount = model.DurationUnitCount ?? 1;
            durationUnitMeasureKind = model.DurationUnitMeasureKind ?? Framework.Decisor.Legal.Persistence.Enumerations.DurationUnitMeasureKind.Years;
            paymentTerm = model.PaymentTerm;
            client = model.Client;
            bankAccount = model.BankAccount;
            TrainingServices = [.. model.TrainingServices];
            SampleAnalysisServices = [.. model.SampleAnalysisServices];
            GroundIntegralStudyServices = [.. model.GroundIntegralStudyServices];
        }

        public int Id { get => id; set => SetProperty(ref id, value); }

        public int Year { get => year; set => SetProperty(ref year, value); }

        public string Objective { get => objective; set => SetProperty(ref objective, value); }

        public System.DateTime StartAt { get => startAt; set => SetProperty(ref startAt, value); }

        public int DurationUnitCount { get => durationUnitCount; set => SetProperty(ref durationUnitCount, value); }

        public Framework.Decisor.Legal.Persistence.Enumerations.DurationUnitMeasureKind DurationUnitMeasureKind { get => durationUnitMeasureKind; set => SetProperty(ref durationUnitMeasureKind, value); }

        public Framework.Decisor.Commercial.Interop.API.Common.Models.Display.PaymentTermDisplayModel PaymentTerm { get => paymentTerm; set => SetProperty(ref paymentTerm, value); }

        public Framework.Decisor.Commercial.Interop.API.Common.Models.Display.LegalClientDisplayModel Client { get => client; set => SetProperty(ref client, value); }

        public Framework.Decisor.Financial.Interop.API.Common.Models.Display.BankAccountDisplayModel BanckAccount { get => bankAccount; set => SetProperty(ref bankAccount, value); }

        public System.Collections.ObjectModel.ObservableCollection<Interop.API.Common.Models.Display.TrainingServiceDisplayModel> TrainingServices { get; set; } = [];

        public System.Collections.ObjectModel.ObservableCollection<Interop.API.Common.Models.Display.SampleAnalysisServiceDisplayModel> SampleAnalysisServices { get; set; } = [];

        public System.Collections.ObjectModel.ObservableCollection<Interop.API.Common.Models.Display.GroundIntegralStudyServiceDisplayModel> GroundIntegralStudyServices { get; set; } = [];

        public Framework.Decisor.Legal.Persistence.Enumerations.DurationUnitMeasureKind[] AvailableDurationUnitMeasureKinds { get; } = [
            Framework.Decisor.Legal.Persistence.Enumerations.DurationUnitMeasureKind.Years, 
            Framework.Decisor.Legal.Persistence.Enumerations.DurationUnitMeasureKind.Months, 
            Framework.Decisor.Legal.Persistence.Enumerations.DurationUnitMeasureKind.Days, 
            Framework.Decisor.Legal.Persistence.Enumerations.DurationUnitMeasureKind.Hours
        ];

        public Framework.Decisor.Commercial.Interop.API.Common.Models.Display.PaymentTermDisplayModel[] AvailablePaymentTerms { get; set; } = [];
    }
}
