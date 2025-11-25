namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Display.Contract
{
    public abstract class AbstractServiceOrderDisplayModel<TEntity> : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<TEntity, long> where TEntity : Persistence.Entities.Contract.AbstractServiceOrder
    {
        public long Id { get; set; }

        public System.DateTime At { get; set; }

        public string Description { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        public virtual void Import(TEntity entity)
        {
            Id = entity.Id;
            At = entity.At;
            Description = entity.Description;
            Enabled = entity.Enabled;
            Priority = entity.Priority;
        }
    }
}
