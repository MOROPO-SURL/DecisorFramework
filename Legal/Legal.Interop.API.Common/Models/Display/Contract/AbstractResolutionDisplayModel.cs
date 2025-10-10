namespace MOROPO.Framework.Decisor.Legal.Interop.API.Common.Models.Display.Contract
{
    public abstract class AbstractResolutionDisplayModel<TResolution> : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<TResolution, System.Guid>
        where TResolution : Persistence.Entities.Contract.AbstractResolution
    {
        public System.Guid Id { get; set; }

        public int Index { get; set; }

        public int Year { get; set; }

        public System.DateTime At { get; set; }

        public string Summary { get; set; }

        public virtual void Import(TResolution entity)
        {
            Id = entity.Id;
            Index = entity.Index;
            Year = entity.Year;
            At = entity.At;
            Summary = entity.Summary;
        }
    }
}
