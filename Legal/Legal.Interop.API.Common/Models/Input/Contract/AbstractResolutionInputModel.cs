namespace MOROPO.Framework.Decisor.Legal.Interop.API.Common.Models.Input.Contract
{
    public abstract class AbstractResolutionInputModel<TResolution> : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<TResolution, long>
        where TResolution : Persistence.Entities.Contract.AbstractResolution, new()
    {
        public long Id { get; set; }

        public System.DateTime At { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Summary { get; set; }

        public TResolution Export()
        {
            var entity = new TResolution { Id = Id };

            Mergue(entity);

            return entity;
        }

        public void Import(TResolution entity)
        {
            throw new System.NotImplementedException();
        }

        public virtual void Mergue(TResolution entity)
        {
            entity.At = At;
            entity.Summary = Summary;
        }
    }
}
