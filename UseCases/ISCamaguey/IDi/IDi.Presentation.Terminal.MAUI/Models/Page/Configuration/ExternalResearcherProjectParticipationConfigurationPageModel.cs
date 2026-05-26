using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Contract;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.Models.Page.Configuration;

public sealed class ExternalResearcherProjectParticipationConfigurationPageModel : AbstractConfigurationPageModel<ExternalResearcherProjectParticipationDisplayModel>
{
    public static string ResearcherValidableProperty => nameof(Researcher);
    public static string TimeAvailabilityValidableProperty => nameof(TimeAvailability);

    private ExternalResearcherDisplayModel researcher;
    private int timeAvailability;
    private System.DateTime startAt;
    private System.DateTime endAt;

    public ExternalResearcherProjectParticipationConfigurationPageModel(ExternalResearcherProjectParticipationDisplayModel model) : base(model)
    {

        timeAvailability = 4;
        startAt = System.DateTime.Now;
        endAt = System.DateTime.Now;

        if (model == null) return;

        researcher = model.Researcher;
        timeAvailability = model.TimeAvailability;
        startAt = model.StartAt;
        endAt = model.EndAt;
    }

    public ExternalResearcherDisplayModel Researcher { get => researcher; set => SetProperty(ref researcher, value); }

    public int TimeAvailability { get => timeAvailability; set => SetProperty(ref timeAvailability, value); }

    public System.DateTime StartAt { get => startAt; set => SetProperty(ref startAt, value); }

    public System.DateTime EndAt { get => endAt; set => SetProperty(ref endAt, value); }
}