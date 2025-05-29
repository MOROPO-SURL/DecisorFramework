namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.View
{
    public class WorkforceConfigurationOrganizationalUnityViewModel
    {
        public System.Guid Id { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        public string Name { get; set; }

        public string Reference { get; set; }

        public System.Collections.ObjectModel.ObservableCollection<WorkforceConfigurationVacantViewModel> Vacants { get; set; } = [];

        public WorkforceConfigurationOrganizationalUnityViewModel[] Children { get; set; }
    }
}
