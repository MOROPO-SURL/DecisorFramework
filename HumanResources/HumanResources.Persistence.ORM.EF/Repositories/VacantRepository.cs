using Microsoft.EntityFrameworkCore;
using MOROPO.Framework.Decisor.HumanResources.Persistence.Entities;
using System.Linq;

namespace MOROPO.Framework.Decisor.HumanResources.Persistence.ORM.EF.Repositories
{
    public class VacantRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.Vacant, System.Guid>
    {
        public VacantRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<Vacant> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.WorkPosition)
                .Include(entity => entity.SalaryStandard);
        }
    }
}
