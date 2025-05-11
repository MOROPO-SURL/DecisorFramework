using System.Collections.Generic;
using MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Display;

namespace MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Input
{
    public class PropertyLeaseOfferInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.PropertyLeaseOffer, System.Guid>
    {
        public System.Guid Id { get; set; }

        public int Priority { get; set; }

        public System.DateTime OpenAt { get; set; }

        public System.DateTime? ClosedAt { get; set; }

        public string Description { get; set; }

        public System.Guid PropertyId { get; set; }

        public List<CommonLeasePersonPostulationInputModel> EditionPersonPostulations { get; set; } = new List<CommonLeasePersonPostulationInputModel>();
        public List<CommonLeasePersonPostulationInputModel> IncomingPersonPostulations { get; set; } = new List<CommonLeasePersonPostulationInputModel>();
        public List<CommonLeasePersonPostulationDisplayModel> OutgoingPersonPostulations { get; set; } = new List<CommonLeasePersonPostulationDisplayModel>();

        public List<CommonLeaseOrganizationPostulationInputModel> EditionOrganizationPostulations { get; set; } = new List<CommonLeaseOrganizationPostulationInputModel>();
        public List<CommonLeaseOrganizationPostulationInputModel> IncomingOrganizationPostulations { get; set; } = new List<CommonLeaseOrganizationPostulationInputModel>();
        public List<CommonLeaseOrganizationPostulationDisplayModel> OutgoingOrganizationPostulations { get; set; } = new List<CommonLeaseOrganizationPostulationDisplayModel>();

        public Persistence.Entities.PropertyLeaseOffer Export()
        {
            var entity = new Persistence.Entities.PropertyLeaseOffer { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.PropertyLeaseOffer entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.PropertyLeaseOffer entity)
        {
            entity.Priority = Priority;
            entity.OpenAt = OpenAt;
            entity.ClosedAt = ClosedAt;
            entity.Description = Description;

            if (entity.PropertyId != PropertyId)
            {
                entity.Property = null;
                entity.PropertyId = PropertyId;
            }
        }
    }
}
