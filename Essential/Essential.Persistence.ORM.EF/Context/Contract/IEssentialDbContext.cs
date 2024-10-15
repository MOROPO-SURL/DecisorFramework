using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.Essential.Persistence.ORM.EF.Context.Contract
{
	public interface IEssentialDbContext
    {
        public DbSet<Entities.Employee> Employees { get; set; }
        public DbSet<Entities.Colaborator> Colaborators { get; set; }
        public DbSet<Entities.UnitMeasurement> UnitMeasurements { get; set; }
        public DbSet<Entities.UnitMeasurementConversionBridge> UnitMeasurementConversionBridges { get; set; }
    }
}