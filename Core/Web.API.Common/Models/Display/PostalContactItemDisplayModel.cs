namespace MOROPO.Framework.Decisor.Core.Web.API.Common.Models.Display
{
    public class PostalContactItemDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Guama.Identity.Persistence.Entities.PostalContactItem, System.Guid>
    {
        public System.Guid Id { get; set; }

        public string Label { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
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
            Municipality = new MunicipalityDisplayModel();

            Municipality.Import(((Guama.Location.Persistence.Entities.MunicipalityLocation)entity.Location).Municipality);
        }
    }
}
