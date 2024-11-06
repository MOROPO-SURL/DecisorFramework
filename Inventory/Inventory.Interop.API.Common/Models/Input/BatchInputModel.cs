namespace MOROPO.Framework.Decisor.Inventory.Interop.API.Common.Models.Input
{
    public class BatchInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.Batch, System.Guid>
    {
        public System.Guid Id { get; set; }

        public string ExternalReference { get; set; }

        public decimal Amount { get; set; }

        public System.Guid WarehouseId { get; set; }

        public System.Guid? ClassificationId { get; set; }

        public Persistence.Entities.Batch Export()
        {
            var entity = new Persistence.Entities.Batch();

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.Batch entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.Batch entity)
        {
            entity.ExternalReference = ExternalReference;
            entity.Amount = Amount;
            entity.WarehouseId = WarehouseId;
            entity.ClassificationId = ClassificationId;
        }
    }
}
