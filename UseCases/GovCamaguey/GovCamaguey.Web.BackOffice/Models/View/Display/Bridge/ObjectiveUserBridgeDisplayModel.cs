using MOROPO.Framework.Guama.Security.Personal.Presentation.Web.Backend.Models.View;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Web.BackOffice.Models.View.Display.Bridge;

public class ObjectiveUserBridgeDisplayModel
{
    public UserDisplayViewModel User { get; set; }

    public bool IsProyectionsIncluded { get; set; }

    public bool IsActionsIncluded { get; set; }
}
