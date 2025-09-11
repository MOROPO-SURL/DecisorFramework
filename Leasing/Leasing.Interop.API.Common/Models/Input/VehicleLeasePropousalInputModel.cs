namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input
{
    public class VehicleLeasePropousalInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.VehicleLeasePropousal, System.Guid>
    {
        public System.Guid Id { get; set; }

        public int Priority { get; set; }

        public System.Guid AuthorId { get; set; }

        public string Description { get; set; }

        public System.Guid AgreementId { get; set; }

        public System.Guid VehicleId { get; set; }

        public Persistence.Entities.VehicleLeasePropousal Export()
        {
            var entity = new Persistence.Entities.VehicleLeasePropousal { Id = Id };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.VehicleLeasePropousal entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.VehicleLeasePropousal entity)
        {
            entity.Priority = Priority;
            entity.Description = Description;

            if (entity.AuthorId != AuthorId)
            {
                entity.Author = null;
                entity.AuthorId = AuthorId;
            }

            if (entity.AgreementId != AgreementId)
            {
                entity.Agreement = null;
                entity.AgreementId = AgreementId;
            }

            if (entity.VehicleId != VehicleId)
            {
                entity.Vehicle = null;
                entity.VehicleId = VehicleId;
            }
        }
    }
}
