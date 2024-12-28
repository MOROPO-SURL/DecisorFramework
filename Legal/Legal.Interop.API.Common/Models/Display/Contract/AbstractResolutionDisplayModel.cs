namespace MOROPO.Framework.Decisor.Legal.Interop.API.Common.Models.Display.Contract
{
    public abstract class AbstractResolutionDisplayModel<TResolution> : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<TResolution, long>
        where TResolution : Persistence.Entities.Contract.AbstractResolution
    {
        public long Id { get; set; }

        public System.DateTime At { get; set; }

        public string Summary { get; set; }

        public virtual void Import(TResolution entity)
        {
            Id = entity.Id;
            At = entity.At;
            Summary = entity.Summary;
        }
    }
}
