namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input
{
    public class PropertyLeaseOrganizationPostulationInputModel : Contract.AbstractLeaseOrganizationPostulationInputModel<Persistence.Entities.PropertyLeaseOrganizationPostulation>
    {
        public System.Guid OfferId { get; set; }

        public override Persistence.Entities.PropertyLeaseOrganizationPostulation Export()
        {
            var entity = new Persistence.Entities.PropertyLeaseOrganizationPostulation { Id = Id, OfferId = OfferId };

            Mergue(entity);

            return entity;
        }
    }
}
