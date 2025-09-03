namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities.Contract
{
    public abstract class AbstractLeaseContract : Legal.Persistence.Entities.Contract.AbstractContract
    {
        public double Feed { get; set; }

        public Legal.Persistence.Enumerations.DurationUnitMeasureKind FeedDurationUnitMeasureKind { get; set; }
    }
}