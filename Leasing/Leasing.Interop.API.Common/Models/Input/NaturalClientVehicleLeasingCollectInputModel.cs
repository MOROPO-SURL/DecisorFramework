namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input
{
    public class NaturalClientVehicleLeasingCollectInputModel : Financial.Interop.API.Common.Models.Input.Contract.AbstractCollectInputModel<Persistence.Entities.NaturalClientVehicleLeasingCollect>
    {
        public System.Guid LeasingId { get; set; }

        public override Persistence.Entities.NaturalClientVehicleLeasingCollect Export()
        {
            var entity = new Persistence.Entities.NaturalClientVehicleLeasingCollect { Id = Id, ExpectedAt = ExpectedAt };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Persistence.Entities.NaturalClientVehicleLeasingCollect entity)
        {
            base.Mergue(entity);

            if (entity.NaturalClientVehicleLeasingId != LeasingId)
            {
                entity.Leasing = null;
                entity.NaturalClientVehicleLeasingId = LeasingId;
            }
        }
    }
}
