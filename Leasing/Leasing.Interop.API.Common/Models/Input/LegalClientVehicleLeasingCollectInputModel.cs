namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input
{
    public class LegalClientVehicleLeasingCollectInputModel : Financial.Interop.API.Common.Models.Input.Contract.AbstractCollectInputModel<Persistence.Entities.LegalClientVehicleLeasingCollect>
    {
        public System.Guid LeasingId { get; set; }

        public override Persistence.Entities.LegalClientVehicleLeasingCollect Export()
        {
            var entity = new Persistence.Entities.LegalClientVehicleLeasingCollect { Id = Id, ExpectedAt = ExpectedAt };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Persistence.Entities.LegalClientVehicleLeasingCollect entity)
        {
            base.Mergue(entity);

            if (entity.LegalClientVehicleLeasingId != LeasingId)
            {
                entity.Leasing = null;
                entity.LegalClientVehicleLeasingId = LeasingId;
            }
        }
    }
}
