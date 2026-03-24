namespace MOROPO.Framework.Decisor.Legal.Interop.API.Common.Models.Input.Contract
{
    public abstract class AbstractResolutionInputModel<TResolution> : Core.Interop.API.Common.Models.Input.Contract.AbstractNotificableEntityInputModel<TResolution, System.Guid>
        where TResolution : Persistence.Entities.Contract.AbstractResolution, new()
    {
        public int Index { get; set; }

        public System.DateTime At { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MaxLength(2048)]
        public string Summary { get; set; }

        public override TResolution Export()
        {
            var entity = new TResolution { Id = Id };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(TResolution entity)
        {
            entity.Index = Index;
            entity.Year = At.Year;
            entity.At = At;
            entity.Summary = Summary;
        }
    }
}
