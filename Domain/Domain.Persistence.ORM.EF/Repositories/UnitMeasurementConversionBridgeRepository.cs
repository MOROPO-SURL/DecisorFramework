namespace MOROPO.Framework.Decisor.Domain.Persistence.ORM.EF.Repositories
{
    public class UnitMeasurementConversionBridgeRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractBridgeRepository<Entities.UnitMeasurementConversionBridge, Entities.UnitMeasurement, System.Guid, Entities.UnitMeasurement, System.Guid>
    {
        public UnitMeasurementConversionBridgeRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }
    }
}
