namespace MOROPO.Framework.Decisor.Legal.Interop.API.Common.Models.Display.Contract
{
    public abstract class AbstractContractDisplayModel<TEntity> : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<TEntity, System.Guid>, Core.Persistence.Entities.Contract.IYearIndexable where TEntity : Persistence.Entities.Contract.AbstractContract
    {
        public System.Guid Id { get; set; }

        public int Index { get; set; }

        public int Year { get; set; }

        public System.DateTime At { get; set; }

        public string Objective { get; set; }

        public System.DateTime StarAt { get; set; }

        public int? DurationUnitCount { get; set; }

        public Persistence.Enumerations.DurationUnitMeasureKind? DurationUnitMeasureKind { get; set; }

        public virtual void Import(TEntity entity)
        {
            Id = entity.Id;
            Index = entity.Index;
            Year = entity.Year;
            At = entity.At;
            Objective = entity.Objective;
            StarAt = entity.StarAt;
            DurationUnitCount = entity.DurationUnitCount;
            DurationUnitMeasureKind = entity.DurationUnitMeasureKind;
        }
    }
}
