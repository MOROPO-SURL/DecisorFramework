namespace MOROPO.Framework.Decisor.Supervision.Presentation.Terminal.MAUI.Models.View
{
    public class ChartViewModel : Caney.MVVM.Core.Models.BaseBindableModel
    {
        private LiveChartsCore.ISeries[] series;

        public LiveChartsCore.ISeries[] Series { get => series; set => SetProperty(ref series, value); }

        public LiveChartsCore.Kernel.Sketches.ICartesianAxis[] XAxes { get; set; }

        public LiveChartsCore.Kernel.Sketches.ICartesianAxis[] YAxes { get; set; }
    }
}