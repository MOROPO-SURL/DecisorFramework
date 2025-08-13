namespace MOROPO.Framework.Decisor.Leasing.Persistence.ORM.EF.Repositories
{
    public class PropertyLeaseOrganizationPostulationRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.PropertyLeaseOrganizationPostulation, System.Guid>
    {
        public PropertyLeaseOrganizationPostulationRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }
    }
}
