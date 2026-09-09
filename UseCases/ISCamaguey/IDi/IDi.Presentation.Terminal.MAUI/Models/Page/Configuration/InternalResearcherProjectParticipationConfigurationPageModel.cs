using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Contract;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.Models.Page.Configuration;

public sealed class InternalResearcherProjectParticipationConfigurationPageModel : AbstractConfigurationPageModel<Interop.API.Common.Models.Display.InternalResearcherProjectParticipationDisplayModel>
{
    public static string ResearcherValidableProperty => nameof(Researcher);
    public static string TimeAvailabilityValidableProperty => nameof(TimeAvailability);

    private Interop.API.Common.Models.Display.InternalResearcherDisplayModel researcher;
    private int timeAvailability;
    private System.DateTime startAt;
    private System.DateTime endAt;

    public InternalResearcherProjectParticipationConfigurationPageModel(Interop.API.Common.Models.Display.InternalResearcherProjectParticipationDisplayModel model) : base(model)
    {

        timeAvailability = 4;
        startAt = System.DateTime.Now;
        endAt = System.DateTime.Now;

        if (model == null) return;

        Id = model.Id;

        researcher = model.Researcher;
        timeAvailability = model.TimeAvailability;
        startAt = model.StartAt;
        endAt = model.EndAt;
    }

    public System.Guid Id { get; set; }

    public Interop.API.Common.Models.Display.InternalResearcherDisplayModel Researcher { get => researcher; set => SetProperty(ref researcher, value); }

    public int TimeAvailability { get => timeAvailability; set => SetProperty(ref timeAvailability, value); }

    public System.DateTime StartAt { get => startAt; set => SetProperty(ref startAt, value); }

    public System.DateTime EndAt { get => endAt; set => SetProperty(ref endAt, value); }
}