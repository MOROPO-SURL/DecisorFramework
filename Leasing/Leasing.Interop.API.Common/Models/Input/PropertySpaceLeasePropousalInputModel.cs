namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input
{
    public class PropertySpaceLeasePropousalInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.PropertySpaceLeasePropousal, System.Guid>
    {
        public System.Guid Id { get; set; }

        public System.Guid PropertySpaceId { get; set; }

        public Persistence.Entities.PropertySpaceLeasePropousal Export()
        {
            var entity = new Persistence.Entities.PropertySpaceLeasePropousal { Id = Id };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.PropertySpaceLeasePropousal entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.PropertySpaceLeasePropousal entity)
        {
            if (entity.PropertySpaceId != PropertySpaceId)
            {
                entity.PropertySpace = null;
                entity.PropertySpaceId = PropertySpaceId;
            }
        }
    }
}
