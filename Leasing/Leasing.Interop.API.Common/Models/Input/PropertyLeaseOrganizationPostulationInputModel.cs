using System.Collections.Generic;

namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input
{
    public class PropertyLeaseOrganizationPostulationInputModel : Contract.AbstractLeaseOrganizationPostulationInputModel<Persistence.Entities.PropertyLeaseOrganizationPostulation>
    {
        public System.Guid OfferId { get; set; }

        public List<Display.PropertySpaceLeasePropousalDisplayModel> IncomingSpaces { get; set; } = new List<Display.PropertySpaceLeasePropousalDisplayModel>();
        public List<Display.PropertySpaceLeasePropousalDisplayModel> OutgoingSpaces { get; set; } = new List<Display.PropertySpaceLeasePropousalDisplayModel>();

        public override Persistence.Entities.PropertyLeaseOrganizationPostulation Export()
        {
            var entity = new Persistence.Entities.PropertyLeaseOrganizationPostulation { Id = Id, OfferId = OfferId };

            Mergue(entity);

            return entity;
        }
    }
}
