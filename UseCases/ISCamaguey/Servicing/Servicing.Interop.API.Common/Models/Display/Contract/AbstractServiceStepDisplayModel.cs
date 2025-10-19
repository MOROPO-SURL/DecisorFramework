namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Display.Contract
{
    public abstract class AbstractServiceStepDisplayModel<TEntity> : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<TEntity, System.Guid> where TEntity : Persistence.Entities.Contract.AbstractServiceStep
    {
        public System.Guid Id { get; set; }

        public string Name { get; set; }

        public int Priority { get; set; }

        public string Description { get; set; }

        public virtual void Import(TEntity entity)
        {
            Id = entity.Id; 
            Name = entity.Name;
            Priority = entity.Priority;
            Description = entity.Description;
        }
    }
}
