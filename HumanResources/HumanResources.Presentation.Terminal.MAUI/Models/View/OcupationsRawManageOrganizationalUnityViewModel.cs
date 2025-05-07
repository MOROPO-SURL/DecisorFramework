namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.View
{
    public class OcupationsRawManageOrganizationalUnityViewModel
    {
        public System.Guid Id { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        public string Name { get; set; }

        public string Reference { get; set; }

        public OcupationsRawManageVacantViewModel[] Vacants { get; set; } = [];

        public OcupationsRawManageOrganizationalUnityViewModel[] Children { get; set; }
    }
}
