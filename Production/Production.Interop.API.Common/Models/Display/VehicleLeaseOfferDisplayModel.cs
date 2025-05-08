using System.Linq;

namespace MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Display
{
    public class VehicleLeaseOfferDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.VehicleLeaseOffer, System.Guid>
    {
        public System.Guid Id { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        public System.DateTime At { get; set; } = System.DateTime.Now;

        public System.DateTime OpenAt { get; set; }

        public System.DateTime? ClosedAt { get; set; }

        public string Description { get; set; }

        public Domain.Interop.API.Common.Models.Display.VehicleDisplayModel Vehicle { get; set; }

        public Bridge.CommonLeaseOfferOrganizationContactBridgeDisplayModel[] OrganizationContactBridges { get; set; }

        public Bridge.CommonLeaseOfferPersonContactBridgeDisplayModel[] PersonContactBridges { get; set; }

        public void Import(Persistence.Entities.VehicleLeaseOffer entity)
        {
            Id = entity.Id;
            Enabled = entity.Enabled;
            Priority = entity.Priority;
            At = entity.At;
            OpenAt = entity.OpenAt;
            ClosedAt = entity.ClosedAt;
            Description = entity.Description;            

            if (entity.Vehicle != null)
            {
                Vehicle = new Domain.Interop.API.Common.Models.Display.VehicleDisplayModel();

                Vehicle.Import(entity.Vehicle);
            }
        }
    }
}
