namespace MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Display.Bridge
{
    public class CommonLeaseOfferOrganizationContactBridgeDisplayModel
    {
        public Domain.Interop.API.Common.Models.Display.OrganizationContactDisplayModel Contact { get; set; }

        public Core.Interop.API.Common.Models.Display.DocumentDisplayModel CredentialDocument { get; set; }

        public string TaxIdentificationNumber { get; set; }

        public string StateIdentificationCode { get; set; }

        public string Argument { get; set; }
    }
}
