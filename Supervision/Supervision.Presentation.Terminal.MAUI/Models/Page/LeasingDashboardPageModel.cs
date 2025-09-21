namespace MOROPO.Framework.Decisor.Supervision.Presentation.Terminal.MAUI.Models.Page
{
    public class LeasingDashboardPageModel : Caney.MVVM.Core.Models.Page.BasePageModel
    {
        private View.ChartViewModel clientPaymentPertinenceHeatChart;
        private long propousalCount;
        private long offerCount;
        private long postulationCount;
        private long leasingCount;
        private long endingContractCount;
        private long endedContractCount;

        public View.ChartViewModel VehicleAssignmentPieChart { get; set; }

        public View.ChartViewModel VehicleLeasingPieChart { get; set; }

        public View.ChartViewModel PropertySpaceAssignmentPieChart { get; set; }

        public View.ChartViewModel PropertyLeasingPieChart { get; set; }

        public View.ChartViewModel ClientPaymentPertinenceHeatChart { get => clientPaymentPertinenceHeatChart; set => SetProperty(ref clientPaymentPertinenceHeatChart, value); }

        public long PropousalCount { get => propousalCount; set => SetProperty(ref propousalCount, value); }

        public long OfferCount { get => offerCount; set => SetProperty(ref offerCount, value); }

        public long PostulationCount { get => postulationCount; set => SetProperty(ref postulationCount, value); }

        public long LeasingCount { get => leasingCount; set => SetProperty(ref leasingCount, value); }

        public long EndingContractCount { get => endingContractCount; set => SetProperty(ref endingContractCount, value); }

        public long EndedContractCount { get => endedContractCount; set => SetProperty(ref endedContractCount, value); }
    }
}
