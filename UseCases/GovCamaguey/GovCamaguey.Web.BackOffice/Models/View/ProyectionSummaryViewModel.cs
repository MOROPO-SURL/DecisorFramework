using MOROPO.GovCamaguey.Decisor.Prototype.Web.BackOffice.Models.View.Contract;
using System.Linq;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Web.BackOffice.Models.View;

public class ProyectionSummaryViewModel : AbstractProyectionViewModel
{
    public ProyectionSummaryViewModel(Prototype.Persistence.Entities.Proyection entity, int objectiveIndex) : base(entity, objectiveIndex)
    {
        Description = entity.Description;
        Guidelines = [.. entity.GuidelineBridges.Select(bridge => bridge.Stern)];
        ResponsabilityOrganizations = [.. entity.OrganizationResponsabilityBridges.Select(bridge => bridge.Stern)];
        ParticipationOrganizations = [.. entity.OrganizationParticipationBridges.Select(bridge => bridge.Stern)];

        ObjectiveIndex = objectiveIndex;

        Actions = [.. entity.Actions];
    }

    public Prototype.Persistence.Entities.Guideline[] Guidelines { get; set; }

    public Prototype.Persistence.Entities.Organization[] ResponsabilityOrganizations { get; set; }

    public Prototype.Persistence.Entities.Organization[] ParticipationOrganizations { get; set; }

    public Prototype.Persistence.Entities.Action[] Actions { get; set; }
}
