using MOROPO.Framework.Decisor.Inventory.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Inventory.Persistence.ORM.EF.Repositories
{
    public class UnitMeasurementConversionBridgeRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractBridgeRepository<UnitMeasurementConversionBridge, UnitMeasurement, System.Guid, UnitMeasurement, System.Guid>
    {
        public UnitMeasurementConversionBridgeRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }
    }
}
