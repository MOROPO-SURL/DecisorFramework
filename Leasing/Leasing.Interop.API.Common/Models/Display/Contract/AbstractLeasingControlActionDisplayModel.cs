namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display.Contract
{
    public abstract class AbstractLeasingControlActionDisplayModel<TEntity> : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<TEntity, System.Guid>
        where TEntity : Persistence.Entities.Contract.AbstractLeasingControlAction
    {
        public System.Guid Id { get; set; }

        public System.DateTime At { get; set; }

        public string Description { get; set; }

        public SupervisionGroupDisplayModel SupervisionGroup { get; set; }

        public virtual void Import(TEntity entity)
        {
            Id = entity.Id;
            At = entity.At;
            Description = entity.Description;

            if (entity.SupervisionGroup != null)
            {
                SupervisionGroup = new SupervisionGroupDisplayModel();

                SupervisionGroup.Import(entity.SupervisionGroup);
            }
        }
    }
}
