using MOROPO.GovCamaguey.Decisor.Prototype.Web.BackOffice.Models.View.Contract;
using System.Linq;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Web.BackOffice.Models.View;

public class ProyectionSummaryViewModel : AbstractProyectionViewModel
{
    public ProyectionSummaryViewModel(Prototype.Persistence.Entities.Proyection entity, int objectiveIndex) : base(entity, objectiveIndex)
    {
        Description = entity.Description;
        Guidelines = [.. entity.GuidelineBridges.Where(bridge => !bridge.Stern.Archived).Select(bridge => bridge.Stern)];
        ResponsabilityOrganizations = [.. entity.OrganizationResponsabilityBridges.Where(bridge => !bridge.Stern.Archived).Select(bridge => bridge.Stern).OrderBy(item => item.Priority)];
        ParticipationOrganizations = [.. entity.OrganizationParticipationBridges.Where(bridge => !bridge.Stern.Archived).Select(bridge => bridge.Stern).OrderBy(item => item.Priority)];

        ObjectiveIndex = objectiveIndex;

        Actions = [.. entity.Actions.Where(entity => !entity.Archived).OrderBy(entity => entity.Index)];
    }

    public Prototype.Persistence.Entities.Guideline[] Guidelines { get; set; }

    public Prototype.Persistence.Entities.Organization[] ResponsabilityOrganizations { get; set; }

    public Prototype.Persistence.Entities.Organization[] ParticipationOrganizations { get; set; }

    public Prototype.Persistence.Entities.Action[] Actions { get; set; }
}
