namespace MOROPO.Framework.Decisor.Legal.Interop.API.Common.Models.Display.Contract
{
    public abstract class AbstractContractDisplayModel<TEntity> : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<TEntity, int> where TEntity : Persistence.Entities.Contract.AbstractContract
    {
        public int Id { get; set; }

        public int Year { get; set; }

        public int Priority { get; set; }

        public System.DateTime At { get; set; }

        public string Objective { get; set; }

        public System.DateTime StarAt { get; set; }

        public int? DurationUnitCount { get; set; }

        public Persistence.Enumerations.DurationUnitMeasureKind? DurationUnitMeasureKind { get; set; }

        public virtual void Import(TEntity entity)
        {
            Id = entity.Id;
            Year = entity.Year;
            Priority = entity.Priority;
            At = entity.At;
            Objective = entity.Objective;
            StarAt = entity.StarAt;
            DurationUnitCount = entity.DurationUnitCount;
            DurationUnitMeasureKind = entity.DurationUnitMeasureKind;
        }
    }
}
