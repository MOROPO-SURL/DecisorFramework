namespace MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Input
{
    public class ServiceOrderSampleInputModel : Contract.AbstractSampleInputModel<Persistence.Entities.ServiceOrderSample>
    {
        public long ServiceOrderId { get; set; }

        public override Persistence.Entities.ServiceOrderSample Export()
        {
            var entity = new Persistence.Entities.ServiceOrderSample { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Persistence.Entities.ServiceOrderSample entity)
        {
            base.Mergue(entity);

            if (entity.ServiceOrderId != ServiceOrderId)
            {
                entity.Order = null;
                entity.ServiceOrderId = ServiceOrderId;
            }
        }
    }
}
