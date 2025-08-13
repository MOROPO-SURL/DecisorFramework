namespace MOROPO.Framework.Decisor.Leasing.Persistence.ORM.EF.Repositories
{
    public class VehicleLeasePersonPostulationRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.VehicleLeasePersonPostulation, System.Guid>
    {
        public VehicleLeasePersonPostulationRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }
    }
}
