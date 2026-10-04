using Microsoft.EntityFrameworkCore;

namespace MOROPO.ISCamaguey.Decisor.Production.Persistence.ORM.EF.Context.Contract;

public interface IProductionDbContext : Framework.Decisor.Domain.Persistence.ORM.EF.Context.Contract.IDomainDbContext, Framework.Decisor.Production.Persistence.ORM.EF.Context.Contract.IProductionDbContext
{
    public DbSet<Entities.ProductionQualityCheck> ProductionQualityChecks { get; set; }
    public DbSet<Entities.ProductionQualityCheckCubanStandardBridge> ProductionQualityCheckCubanStandardBridges { get; set; }
    public DbSet<Entities.ProductionQualityCheckIsoStandardBridge> ProductionQualityCheckIsoStandardBridges { get; set; }
}