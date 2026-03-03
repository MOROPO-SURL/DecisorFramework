namespace MOROPO.GovCamaguey.Decisor.Prototype.Web.BackOffice.Models.View.Input.Bridge;

public class ObjectiveUserBridgeInputModel
{
    [System.ComponentModel.DataAnnotations.Required]
    public string UserId { get; set; }

    public bool IsProyectionsIncluded { get; set; }

    public bool IsActionsIncluded { get; set; }

    public Framework.Guama.Security.Personal.Presentation.Web.Backend.Models.View.UserDisplayViewModel[] AvailableUsers { get; set; } = [];
}
