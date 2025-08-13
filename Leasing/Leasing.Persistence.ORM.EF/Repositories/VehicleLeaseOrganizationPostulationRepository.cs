namespace MOROPO.Framework.Decisor.Leasing.Persistence.ORM.EF.Repositories
{
    public class VehicleLeaseOrganizationPostulationRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.VehicleLeaseOrganizationPostulation, System.Guid>
    {
        public VehicleLeaseOrganizationPostulationRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }
    }
}
