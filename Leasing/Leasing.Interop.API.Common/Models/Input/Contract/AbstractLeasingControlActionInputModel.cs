namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input.Contract
{
    public abstract class AbstractLeasingControlActionInputModel<TEntity> : Core.Interop.API.Common.Models.Input.Contract.AbstractNotificableEntityInputModel<TEntity, System.Guid>
        where TEntity : Persistence.Entities.Contract.AbstractLeasingControlAction
    {
        public System.DateTime At { get; set; }

        public string Description { get; set; }

        public System.Guid SupervisionGroupId { get; set; }

        public override void Mergue(TEntity entity)
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
