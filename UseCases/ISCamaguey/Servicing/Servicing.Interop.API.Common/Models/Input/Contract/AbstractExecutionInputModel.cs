namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Input.Contract
{
    public abstract class AbstractExecutionInputModel<TEntity> : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<TEntity, System.Guid>
        where TEntity : Persistence.Entities.Contract.AbstractExecution
    {
        public System.Guid Id { get; set; }

        public System.DateTime At { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Description { get; set; }

        public System.Guid AuthorId { get; set; }

        public Framework.Decisor.Core.Interop.API.Common.Models.Input.DocumentInputModel Document { get; set; }

        public abstract TEntity Export();

        public void Import(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public virtual void Mergue(TEntity entity)
        {
            entity.At = At;
            entity.Description = Description;

            if (entity.AuthorId != AuthorId)
            {
                entity.Author = null;
                entity.AuthorId = AuthorId;
            }
        }
    }
}
