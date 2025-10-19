namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Display.Contract
{
    public abstract class AbstractServiceDisplayModel<TEntity> : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<TEntity, System.Guid> where TEntity : Persistence.Entities.Contract.AbstractService
    {
        public System.Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        public Framework.Decisor.Core.Interop.API.Common.Models.Display.DocumentDisplayModel[] Documents { get; set; }

        public virtual void Import(TEntity entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Description = entity.Description;
            Enabled = entity.Enabled;
            Priority = entity.Priority;
        }
    }
}
