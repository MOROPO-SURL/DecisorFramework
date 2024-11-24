using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Display;

namespace MOROPO.Framework.Decisor.Financial.Interop.API.Common.Models.Display
{
    public class BankAgencyDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.BankAgency, System.Guid>
    {
        public System.Guid Id { get; set; }

        public int Priority { get; set; }

        public System.DateTime At { get; set; }

        public string Name { get; set; }

        public Core.Interop.API.Common.Models.Display.ImageDisplayModel Image { get; set; }

        public string About { get; set; }

        public void Import(Persistence.Entities.BankAgency entity)
        {
            Id = entity.Id;
            Priority = entity.Priority;
            Name = entity.Name;
            At = entity.At;
            About = entity.About;

            if (entity.Image != null)
            {
                Image = new ImageDisplayModel();

                Image.Import(entity.Image);
            }
        }
    }
}
