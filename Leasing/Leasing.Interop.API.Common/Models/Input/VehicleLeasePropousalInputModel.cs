namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input
{
    public class VehicleLeasePropousalInputModel : Core.Interop.API.Common.Models.Input.Contract.AbstractNotificableEntityInputModel<Persistence.Entities.VehicleLeasePropousal, System.Guid>
    {
        public int Priority { get; set; }

        public System.Guid AuthorId { get; set; }

        public string Description { get; set; }

        public System.Guid AgreementId { get; set; }

        public System.Guid VehicleId { get; set; }

        public decimal BaselineAmount { get; set; }

        public System.Guid BaselineCurrencyId { get; set; }

        public override Persistence.Entities.VehicleLeasePropousal Export()
        {
            var entity = new Persistence.Entities.VehicleLeasePropousal { Id = Id };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Persistence.Entities.VehicleLeasePropousal entity)
        {
            entity.Priority = Priority;
            entity.Description = Description;
            entity.BaselineAmount = BaselineAmount;

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

            if (entity.BaselineCurrencyId != BaselineCurrencyId)
            {
                entity.BaselineCurrency = null;
                entity.BaselineCurrencyId = BaselineCurrencyId;
            }
        }
    }
}
