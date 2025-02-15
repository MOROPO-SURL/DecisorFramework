namespace MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Input
{
    public class PostalContactInputModel
    {
        public System.Guid MunicipalityId { get; set; }

        public string Label { get; set; }

        public string Address { get; set; }

        public int ZipCode { get; set; }

        public decimal Longitude { get; set; }

        public decimal Latitude { get; set; }
    }
}
