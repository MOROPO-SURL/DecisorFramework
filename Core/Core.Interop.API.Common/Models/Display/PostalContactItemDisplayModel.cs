namespace MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Display
{
    public class PostalContactItemDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Guama.Identity.Persistence.Entities.PostalContactItem, System.Guid>
    {
        public System.Guid Id { get; set; }

        public string Label { get; set; }

        public string Address { get; set; }

        public int ZipCode { get; set; }

        public decimal Longitude { get; set; }

        public decimal Latitude { get; set; }

        public MunicipalityDisplayModel Municipality { get; set; }

        public void Import(Guama.Identity.Persistence.Entities.PostalContactItem entity)
        {
            Id = entity.Id;
            Label = entity.Label;
            Address = entity.Address;
            ZipCode = entity.ZipCode;
            Longitude = entity.Longitude;
            Latitude = entity.Latitude;

            Municipality = new MunicipalityDisplayModel { Id = (entity.Location as Guama.Location.Persistence.Entities.MunicipalityLocation).MunicipalityId.Value };
        }
    }
}
