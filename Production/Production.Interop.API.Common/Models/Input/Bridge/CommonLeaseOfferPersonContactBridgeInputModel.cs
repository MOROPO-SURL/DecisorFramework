namespace MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Input.Bridge
{
    public class CommonLeaseOfferPersonContactBridgeInputModel
    {
        public System.Guid ContactId { get; set; }

        public Core.Interop.API.Common.Models.Input.DocumentInputModel RawCredentialDocument { get; set; }

        public System.Guid BusinessKindId { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.RegularExpression("^[0-9]+$")]
        public string TaxIdentificationNumber { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Argument { get; set; }
    }
}
