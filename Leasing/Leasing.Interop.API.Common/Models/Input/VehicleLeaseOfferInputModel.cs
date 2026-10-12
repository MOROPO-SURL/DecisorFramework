namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input
{
    public class VehicleLeaseOfferInputModel : Core.Interop.API.Common.Models.Input.Contract.AbstractNotificableEntityInputModel<Persistence.Entities.VehicleLeaseOffer, System.Guid>
    {
        public int Priority { get; set; }

        public System.DateTime OpenAt { get; set; }

        public System.DateTime? ClosedAt { get; set; }

        public string Description { get; set; }

        public System.Guid AgreementId { get; set; }

        public System.Guid PropousalId { get; set; }

        public decimal BaselineAmount { get; set; }

        public System.Guid BaselineCurrencyId { get; set; }

        public override Persistence.Entities.VehicleLeaseOffer Export()
        {
            var entity = new Persistence.Entities.VehicleLeaseOffer { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Persistence.Entities.VehicleLeaseOffer entity)
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
