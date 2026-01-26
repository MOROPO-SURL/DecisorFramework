namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input
{
    public class VehicleLeaseOfferInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.VehicleLeaseOffer, System.Guid>
    {
        public System.Guid Id { get; set; }

        public int Priority { get; set; }

        public System.DateTime OpenAt { get; set; }

        public System.DateTime? ClosedAt { get; set; }

        public string Description { get; set; }

        public System.Guid AgreementId { get; set; }

        public System.Guid PropousalId { get; set; }

        public decimal BaselineAmount { get; set; }

        public System.Guid BaselineCurrencyId { get; set; }

        public Persistence.Entities.VehicleLeaseOffer Export()
        {
            var entity = new Persistence.Entities.VehicleLeaseOffer { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.VehicleLeaseOffer entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.VehicleLeaseOffer entity)
        {
            entity.Priority = Priority;
            entity.OpenAt = OpenAt;
            entity.ClosedAt = ClosedAt;
            entity.Description = Description;
            entity.BaselineAmount = BaselineAmount;

            if (entity.AgreementId != AgreementId)
            {
                entity.Agreement = null;
                entity.AgreementId = AgreementId;
            }

            if (entity.BaselineCurrencyId != BaselineCurrencyId)
            {
                entity.BaselineCurrency = null;
                entity.BaselineCurrencyId = BaselineCurrencyId;
            }
        }
    }
}
