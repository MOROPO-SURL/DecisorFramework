using System.Collections;

namespace MOROPO.Framework.Decisor.Production.Persistence.Entities
{
    public class VehicleLeaseOffer : Contract.AbstractLeaseOffer
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(VehicleId))]
        public Domain.Persistence.Entities.Vehicle Vehicle { get; set; }
        public System.Guid VehicleId { get; set; }

        public System.Collections.Generic.ICollection<VehicleLeaseOfferOrganizationContactBridge> OrganizationContactBridges { get; set; }

        public System.Collections.Generic.ICollection<VehicleLeaseOfferPersonContactBridge> PersonContactBridges { get; set; }

    }
}