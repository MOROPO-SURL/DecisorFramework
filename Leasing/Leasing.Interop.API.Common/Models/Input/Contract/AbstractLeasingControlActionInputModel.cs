namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input.Contract
{
    public abstract class AbstractLeasingControlActionInputModel<TEntity> : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<TEntity, System.Guid>
        where TEntity : Persistence.Entities.Contract.AbstractLeasingControlAction
    {
        public System.Guid Id { get; set; }

        public System.DateTime At { get; set; }

        public string Description { get; set; }

        public System.Guid SupervisionGroupId { get; set; }

        public abstract TEntity Export();

        public void Import(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public virtual void Mergue(TEntity entity)
        {
            entity.At = At;
            entity.Description = Description;

            if (entity.SupervisionGroupId != SupervisionGroupId)
            {
                entity.SupervisionGroup = null;
                entity.SupervisionGroupId = SupervisionGroupId;
            }
        }
    }
}
