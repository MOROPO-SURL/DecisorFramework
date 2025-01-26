namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display
{
    public class OrganizationalUnityDisplayModel : Domain.Interop.API.Common.Models.Display.Contract.AbstractOrganizationalUnityDisplayModel
    {
        public OrganizationalUnityDisplayModel[] Children { get; set; }

        public VacantDisplayModel[] Vacants { get; set; }
    }
}
