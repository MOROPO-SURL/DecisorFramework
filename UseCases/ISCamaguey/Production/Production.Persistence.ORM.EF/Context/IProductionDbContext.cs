using Microsoft.EntityFrameworkCore;

namespace MOROPO.ISCamaguey.Decisor.Production.Persistence.ORM.EF.Context;

public interface IProductionDbContext : Framework.Decisor.Domain.Persistence.ORM.EF.Context.Contract.IDomainDbContext, Framework.Decisor.Production.Persistence.ORM.EF.Context.Contract.IProductionDbContext
{
    public DbSet<Entities.ProductionQualityCheck> ProductionQualityChecks { get; set; }
}