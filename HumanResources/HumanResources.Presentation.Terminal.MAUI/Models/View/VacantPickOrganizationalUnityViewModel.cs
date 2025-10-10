namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.View
{
    public class VacantPickOrganizationalUnityViewModel
    {
        public System.Guid Id { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        public string Name { get; set; }

        public string Reference { get; set; }

        public Interop.API.Common.Models.Display.VacantDisplayModel[] Vacants { get; set; } = [];

        public VacantPickOrganizationalUnityViewModel[] Children { get; set; }
    }
}
