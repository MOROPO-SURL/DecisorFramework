namespace MOROPO.Framework.Decisor.Leasing.Persistence.ORM.EF.Repositories
{
    public class PropertyLeasePersonPostulationRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.PropertyLeasePersonPostulation, System.Guid>
    {
        public PropertyLeasePersonPostulationRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }
    }
}
