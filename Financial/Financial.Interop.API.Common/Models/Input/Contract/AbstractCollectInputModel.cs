namespace MOROPO.Framework.Decisor.Financial.Interop.API.Common.Models.Input.Contract
{
    public abstract class AbstractCollectInputModel<TEntity> : Core.Interop.API.Common.Models.Input.Contract.AbstractNotificableEntityInputModel<TEntity, System.Guid>
        where TEntity : Persistence.Entities.Contract.AbstractCollect
    {
        public System.DateTime ExpectedAt { get; set; }

        public float Amount { get; set; }

        public string Description { get; set; }

        public override void Mergue(TEntity entity)
        {
            entity.Amount = Amount;
            entity.Description = Description;
        }
    }
}
