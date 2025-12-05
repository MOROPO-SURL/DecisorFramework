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

        public Core.Interop.API.Common.Models.Display.DocumentDisplayModel Document { get; set; }

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

            if (entity.Document != null)
            {
                Document = new Core.Interop.API.Common.Models.Display.DocumentDisplayModel();

                Document.Import(entity.Document);
            }
        }

        [Newtonsoft.Json.JsonIgnore]
        public bool IsEnded
        {
            get
            {
                var now = System.DateTime.Now;

                if (DurationUnitCount != null && DurationUnitCount.Value > 0)
                {
                    var limitDateTime = StarAt;

                    switch (DurationUnitMeasureKind.Value)
                    {
                        case Persistence.Enumerations.DurationUnitMeasureKind.Years:
                            limitDateTime = limitDateTime.AddYears(DurationUnitCount.Value);

                            break;

                        case Persistence.Enumerations.DurationUnitMeasureKind.Months:
                            limitDateTime = limitDateTime.AddMonths(DurationUnitCount.Value);

                            break;

                        case Persistence.Enumerations.DurationUnitMeasureKind.Days:
                            limitDateTime = limitDateTime.AddDays(DurationUnitCount.Value);

                            break;

                        case Persistence.Enumerations.DurationUnitMeasureKind.Hours:
                        default:
                            limitDateTime = limitDateTime.AddHours(DurationUnitCount.Value);

                            break;
                    }

                    if (limitDateTime < now)
                    {
                        return true;
                    }
                }

                return false;
            }
        }
    }
}
