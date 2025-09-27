using Microsoft.EntityFrameworkCore;

namespace MOROPO.ISCamaguey.Decisor.Quality.Persistence.ORM.EF.Context.Contract
{
    public interface IQualityDbContext
    {
        public DbSet<Entities.CubanStandard> CubanStandards { get; set; }
        public DbSet<Entities.IsoStandard> IsoStandards { get; set; }   
        public DbSet<Entities.Certification> Certifications { get; set; }
        public DbSet<Entities.CertificationCubanStandardBridge> CertificationCubanStandardBridges { get; set; }
        public DbSet<Entities.CertificationIsoStandardBridge> CertificationIsoStandardBridges { get; set; }
    }
}