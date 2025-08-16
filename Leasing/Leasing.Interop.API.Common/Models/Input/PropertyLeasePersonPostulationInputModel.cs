namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input
{
    public class PropertyLeasePersonPostulationInputModel : Contract.AbstractLeasePersonPostulationInputModel<Persistence.Entities.PropertyLeasePersonPostulation>
    {
        public System.Guid OfferId { get; set; }

        public override Persistence.Entities.PropertyLeasePersonPostulation Export()
        {
            var entity = new Persistence.Entities.PropertyLeasePersonPostulation { Id = Id, OfferId = OfferId };

            Mergue(entity);

            return entity;
        }
    }
}
