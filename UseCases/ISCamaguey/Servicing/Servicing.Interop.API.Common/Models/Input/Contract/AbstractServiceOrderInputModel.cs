namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Input.Contract
{
    public abstract class AbstractServiceOrderInputModel<TEntity> : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<TEntity, long> where TEntity : Persistence.Entities.Contract.AbstractServiceOrder
    {
        public long Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Description { get; set; }

        public abstract TEntity Export();

        public void Import(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public virtual void Mergue(TEntity entity)
        {
            entity.Description = Description;
        }
    }
}
