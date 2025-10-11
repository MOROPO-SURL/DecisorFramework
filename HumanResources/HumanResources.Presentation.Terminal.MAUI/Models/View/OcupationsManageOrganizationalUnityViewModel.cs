namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.View
{
    public class OcupationsManageOrganizationalUnityViewModel
    {
        public System.Guid Id { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        public string Name { get; set; }

        public string Reference { get; set; }

        public OcupationsManageVacantViewModel[] Vacants { get; set; } = [];

        public OcupationsManageOrganizationalUnityViewModel[] Children { get; set; }
    }
}
