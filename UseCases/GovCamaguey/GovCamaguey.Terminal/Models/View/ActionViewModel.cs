using MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Display;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.Models.View
{
    public class ActionViewModel
    {
        public System.Guid Id { get; set; }

        public bool Enabled { get; set; }

        public int Index { get; set; }

        public int ProyectionIndex { get; set; }

        public int ObjectiveIndex { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public OrganizationDisplayModel[] ResponsabilityOrganizations { get; set; }

        public OrganizationDisplayModel[] ParticipationOrganizations { get; set; }

        public IndicatorDisplayModel[] Indicators { get; set; }

        public ActionMonthlyClosureDisplayModel[] MonthlyClosures { get; set; }

        public ActionViewModel(ActionDisplayModel model, int proyectionIndex, int objectiveIndex) 
        {
            Id = model.Id;
            Enabled = model.Enabled;
            Index = model.Index;
            Name = model.Name;
            Description = model.Description;
            ResponsabilityOrganizations = model.ResponsabilityOrganizations;
            ParticipationOrganizations = model.ParticipationOrganizations;
            Indicators = model.Indicators;
            MonthlyClosures = model.MonthlyClosures;

            ProyectionIndex = proyectionIndex;
            ObjectiveIndex = objectiveIndex;
        }
    }
}
