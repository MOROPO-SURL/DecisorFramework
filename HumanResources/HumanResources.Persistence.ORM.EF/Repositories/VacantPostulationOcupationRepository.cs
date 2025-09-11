using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.HumanResources.Persistence.ORM.EF.Repositories
{
    public class VacantPostulationOcupationRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.VacantPostulationOcupation, System.Guid>
    {
        public VacantPostulationOcupationRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Entities.VacantPostulationOcupation> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet().Include(entity => entity.CentralStateStructure).ThenInclude(entity => entity.Identity);
        }
    }
}
