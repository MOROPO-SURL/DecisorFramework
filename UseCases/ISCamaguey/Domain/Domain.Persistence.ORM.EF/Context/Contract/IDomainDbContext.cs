using Microsoft.EntityFrameworkCore;

namespace MOROPO.ISCamaguey.Decisor.Domain.Persistence.ORM.EF.Context.Contract
{
    public interface IDomainDbContext : Quality.Persistence.ORM.EF.Context.Contract.IQualityDbContext
    {
        public DbSet<Entities.Technique> Techniques { get; set; }
        public DbSet<Entities.TechniqueCubanStandardBridge> TechniqueCubanStandardBridges { get; set; }
        public DbSet<Entities.TechniqueIsoStandardBridge> TechniqueIsoStandardBridges { get; set; }
        public DbSet<Entities.SampleKind> SampleKinds { get; set; }
    }
}