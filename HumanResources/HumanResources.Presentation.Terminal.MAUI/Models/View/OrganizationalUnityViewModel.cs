namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.View
{
    public class OrganizationalUnityViewModel
    {
        public System.Guid Id { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        public string Name { get; set; }

        public string Reference { get; set; }

        public System.Collections.ObjectModel.ObservableCollection<VacantViewModel> Vacants { get; set; } = new System.Collections.ObjectModel.ObservableCollection<VacantViewModel>();

        public OrganizationalUnityViewModel[] Children { get; set; }
    }
}
