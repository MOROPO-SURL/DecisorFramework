namespace MOROPO.Framework.Decisor.Legal.Interop.API.Common.Models.Input.Contract
{
    public abstract class AbstractResolutionInputModel<TResolution> : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<TResolution, System.Guid>
        where TResolution : Persistence.Entities.Contract.AbstractResolution, new()
    {
        public System.Guid Id { get; set; }

        public int Index { get; set; }

        public System.DateTime At { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MaxLength(2048)]
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
            entity.Index = Index;
            entity.Year = At.Year;
            entity.At = At;
            entity.Summary = Summary;
        }
    }
}
