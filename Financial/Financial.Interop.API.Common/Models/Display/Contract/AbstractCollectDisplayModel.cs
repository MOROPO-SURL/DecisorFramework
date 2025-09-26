namespace MOROPO.Framework.Decisor.Financial.Interop.API.Common.Models.Display.Contract
{
    public class AbstractCollectDisplayModel<TEntity> : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<TEntity, System.Guid>
        where TEntity : Persistence.Entities.Contract.AbstractCollect
    {
        public System.Guid Id { get; set; }

        public System.DateTime At { get; set; }

        public System.DateTime ExpectedAt { get; set; }

        public float Amount { get; set; }

        public string Description { get; set; }

        public virtual void Import(TEntity entity)
        {
            Id = entity.Id;
            At = entity.At;
            ExpectedAt = entity.ExpectedAt;
            Amount = entity.Amount;
            Description = entity.Description;
        }
    }
}
