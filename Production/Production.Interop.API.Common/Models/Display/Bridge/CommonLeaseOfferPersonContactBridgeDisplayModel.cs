namespace MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Display.Bridge
{
    public class CommonLeaseOfferPersonContactBridgeDisplayModel
    {
        public Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel Contact { get; set; }

        public Core.Interop.API.Common.Models.Display.DocumentDisplayModel CredentialDocument { get; set; }

        public Domain.Interop.API.Common.Models.Display.NaturalBusinessKindDisplayModel BusinessKind { get; set; }

        public string TaxIdentificationNumber { get; set; }

        public string Argument { get; set; }
    }
}
