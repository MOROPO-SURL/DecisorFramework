using MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Display;
using System.Linq;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.Models.View
{
    public class ProyectionViewModel
    {
        public System.Guid Id { get; set; }

        public bool Enabled { get; set; }

        public int Index { get; set; }

        public int ObjectiveIndex { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public GuidelineDisplayModel[] Guidelines { get; set; }

        public OrganizationDisplayModel[] ResponsabilityOrganizations { get; set; }

        public OrganizationDisplayModel[] ParticipationOrganizations { get; set; }

        public ActionViewModel[] Actions { get; set; }

        public ProyectionViewModel(ProyectionDisplayModel model, int objectiveIndex)
        {
            Id = model.Id;
            Enabled = model.Enabled;
            Index = model.Index;
            Name = model.Name;
            Description = model.Description;
            Guidelines = model.Guidelines;
            ResponsabilityOrganizations = model.ResponsabilityOrganizations;
            ParticipationOrganizations = model.ParticipationOrganizations;

            ObjectiveIndex = objectiveIndex;

            Actions = model.Actions.Select(_model => new ActionViewModel(_model, model.Index, objectiveIndex)).ToArray();
        }
    }
}
