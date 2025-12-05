using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class VacantPostulationOcupationConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.VacantPostulationOcupationDisplayModel>
    {
        private string organizationName;
        private string organizationAddress;
        private string representativeName;
        private CentralStateStructureDisplayModel centralStateStructure;
        private System.DateTime startAt;
        private System.DateTime endAt;

        public VacantPostulationOcupationConfigurationPageModel(Interop.API.Common.Models.Display.VacantPostulationOcupationDisplayModel model) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                organizationName = model.OrganizationName;
                organizationAddress = model.OrganizationAddress;
                representativeName = model.RepresentativeName;
                centralStateStructure = model.CentralStateStructure;
                startAt = model.StartAt;
                endAt = model.EndAt;
            }
            else
            {
                endAt = System.DateTime.Now;
                startAt = endAt.AddYears(-2);
            }
        }

        public System.Guid Id { get; set; }

        public string OrganizationName { get => organizationName; set => SetProperty(ref organizationName, value); }

        public string OrganizationAddress { get => organizationAddress; set => SetProperty(ref organizationAddress, value); }

        public string RepresentativeName { get => representativeName; set => SetProperty(ref representativeName, value); }

        public CentralStateStructureDisplayModel CentralStateStructure { get => centralStateStructure; set => SetProperty(ref centralStateStructure, value); }

        public System.DateTime StartAt { get => startAt; set => SetProperty(ref startAt, value); }

        public System.DateTime EndAt { get => endAt; set => SetProperty(ref endAt, value); }

        public CentralStateStructureDisplayModel[] AvailableCentralStateStructures { get; set; }
    }
}
