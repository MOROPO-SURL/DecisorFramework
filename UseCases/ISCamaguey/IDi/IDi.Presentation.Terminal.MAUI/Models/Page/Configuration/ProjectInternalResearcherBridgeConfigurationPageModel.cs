using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Contract;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display.Relationship;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.Models.Page.Configuration;

public sealed class ProjectInternalResearcherBridgeConfigurationPageModel : AbstractConfigurationPageModel<ProjectInternalResearcherRelationshipDisplayModel>
{
    private InternalResearcherDisplayModel researcher;

    private int iimeAvailability;

    public ProjectInternalResearcherBridgeConfigurationPageModel(ProjectInternalResearcherRelationshipDisplayModel model) : base(model)
    {
    }

    public InternalResearcherDisplayModel Researcher { get => researcher; set => SetProperty(ref researcher, value); }

    public int IimeAvailability { get => iimeAvailability; set => SetProperty(ref iimeAvailability, value); }
}