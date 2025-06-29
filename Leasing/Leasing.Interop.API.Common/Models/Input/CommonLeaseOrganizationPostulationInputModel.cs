namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input
{
    public class CommonLeaseOrganizationPostulationInputModel
    {
        public System.Guid Id { get; set; }

        public System.Guid ContactId { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.RegularExpression("^[0-9]+$")]
        public string TaxIdentificationNumber { get; set; }

        public string StateIdentificationCode { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Argument { get; set; }
    }
}
