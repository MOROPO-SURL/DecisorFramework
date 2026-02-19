namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.View
{
    public class WorkforceConfigurationOrganizationalUnityViewModel : Caney.MVVM.Core.Models.BaseBindableModel
    {
        private WorkforceConfigurationVacantViewModel chiefVacant;

        public System.Guid Id { get; set; }

        public Domain.Interop.API.Common.Models.Display.OrganizationalUnitDisplayModel Domain { get; set; }

        public WorkforceConfigurationVacantViewModel ChiefVacant { get => chiefVacant; set => SetProperty(ref chiefVacant, value); }

        public System.Collections.ObjectModel.ObservableCollection<WorkforceConfigurationVacantViewModel> Vacants { get; set; } = [];

        public WorkforceConfigurationOrganizationalUnityViewModel[] Children { get; set; }
    }
}
