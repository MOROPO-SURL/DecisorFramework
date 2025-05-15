namespace MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Display
{
    public class CommonLeaseOrganizationPostulationDisplayModel
    {
        public System.Guid Id { get; set; }

        public Domain.Interop.API.Common.Models.Display.OrganizationContactDisplayModel Contact { get; set; }

        public string TaxIdentificationNumber { get; set; }

        public string StateIdentificationCode { get; set; }

        public string Argument { get; set; }
    }
}
