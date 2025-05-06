using System.Collections.Generic;

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

        public List<Bridge.CommonLeaseOfferPersonContactBridgeInputModel> EditionPersonContactBridges { get; set; } = new List<Bridge.CommonLeaseOfferPersonContactBridgeInputModel>();
        public List<Bridge.CommonLeaseOfferPersonContactBridgeInputModel> IncomingPersonContactBridges { get; set; } = new List<Bridge.CommonLeaseOfferPersonContactBridgeInputModel>();
        public List<Display.Bridge.CommonLeaseOfferPersonContactBridgeDisplayModel> OutgoingPersonContactBridges { get; set; } = new List<Display.Bridge.CommonLeaseOfferPersonContactBridgeDisplayModel>();

        public List<Bridge.CommonLeaseOfferOrganizationContactBridgeInputModel> EditionOrganizationContactBridges { get; set; } = new List<Bridge.CommonLeaseOfferOrganizationContactBridgeInputModel>();
        public List<Bridge.CommonLeaseOfferOrganizationContactBridgeInputModel> IncomingOrganizationContactBridges { get; set; } = new List<Bridge.CommonLeaseOfferOrganizationContactBridgeInputModel>();
        public List<Display.Bridge.CommonLeaseOfferOrganizationContactBridgeDisplayModel> OutgoingOrganizationContactBridges { get; set; } = new List<Display.Bridge.CommonLeaseOfferOrganizationContactBridgeDisplayModel>();

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
