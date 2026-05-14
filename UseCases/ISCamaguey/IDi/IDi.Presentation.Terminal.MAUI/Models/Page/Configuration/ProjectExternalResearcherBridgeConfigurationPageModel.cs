using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Contract;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Shared.Bridge;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.Models.Page.Configuration;

public sealed class ProjectExternalResearcherBridgeConfigurationPageModel : AbstractConfigurationPageModel<ProjectExternalResearcherBridgeSharedModel>
{
    private ExternalResearcherDisplayModel researcher;

    private int iimeAvailability;

    public ProjectExternalResearcherBridgeConfigurationPageModel(ProjectExternalResearcherBridgeSharedModel model) : base(model)
    {
    }

    public ExternalResearcherDisplayModel Researcher { get => researcher; set => SetProperty(ref researcher, value); }

    public int IimeAvailability { get => iimeAvailability; set => SetProperty(ref iimeAvailability, value); }
}