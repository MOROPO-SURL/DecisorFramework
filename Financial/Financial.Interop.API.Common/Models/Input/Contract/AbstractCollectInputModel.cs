namespace MOROPO.Framework.Decisor.Financial.Interop.API.Common.Models.Input.Contract
{
    public abstract class AbstractCollectInputModel<TEntity> : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<TEntity, System.Guid>
        where TEntity : Persistence.Entities.Contract.AbstractCollect
    {
        public System.Guid Id { get; set; }

        public System.DateTime ExpectedAt { get; set; }

        public float Amount { get; set; }

        public string Description { get; set; }

        public abstract TEntity Export();

        public void Import(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public virtual void Mergue(TEntity entity)
        {
            entity.Amount = Amount;
            entity.Description = Description;
        }
    }
}
