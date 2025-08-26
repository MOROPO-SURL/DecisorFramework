using MOROPO.Framework.Decisor.Legal.Persistence.Enumerations;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class OcupationByAdmisionConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.OcupationDisplayModel>
    {
        private System.DateTime startAt;
        private bool isDetermiteDuration;
        private int duration;
        private DurationUnitMeasureKind durationUnitMeasureKind;

        public OcupationByAdmisionConfigurationPageModel(Interop.API.Common.Models.Display.AdmitionPropousalDisplayModel admitionPropousal, Interop.API.Common.Models.Display.OcupationDisplayModel model) : base(model)
        {
            AdmitionPropousal = admitionPropousal;
        }

        public Interop.API.Common.Models.Display.AdmitionPropousalDisplayModel AdmitionPropousal { get; set; }

        public System.DateTime StartAt { get => startAt; set => startAt = value; }

        public bool IsDetermiteDuration { get => isDetermiteDuration; set => isDetermiteDuration = value; }

        public int Duration { get => duration; set => duration = value; }

        public DurationUnitMeasureKind DurationUnitMeasureKind { get => durationUnitMeasureKind; set => durationUnitMeasureKind = value; }

        public DurationUnitMeasureKind[] AvailableDurationUnitMeasureKinds => [DurationUnitMeasureKind.Years, DurationUnitMeasureKind.Months, DurationUnitMeasureKind.Days, DurationUnitMeasureKind.Hours];
    }
}
