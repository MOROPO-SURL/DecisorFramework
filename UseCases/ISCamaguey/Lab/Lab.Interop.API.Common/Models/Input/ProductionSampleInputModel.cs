namespace MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Input
{
    public class ProductionSampleInputModel : Contract.AbstractSampleInputModel<Persistence.Entities.ProductionSample>
    {
        public System.Guid ProductionId { get; set; }

        public override Persistence.Entities.ProductionSample Export()
        {
            var entity = new Persistence.Entities.ProductionSample { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Persistence.Entities.ProductionSample entity)
        {
            base.Mergue(entity);

            if (entity.ProductionId != ProductionId)
            {
                entity.Production = null;
                entity.ProductionId = ProductionId;
            }
        }
    }
}
