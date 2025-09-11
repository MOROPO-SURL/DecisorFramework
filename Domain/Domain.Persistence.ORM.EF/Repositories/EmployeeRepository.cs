using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MOROPO.Framework.Decisor.Domain.Persistence.ORM.EF.Repositories
{
    public class EmployeeRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.Employee, System.Guid>
    {
        public EmployeeRepository(DbContext dbContext) : base(dbContext) { }

        protected override IQueryable<Entities.Employee> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image);
        }
    }
}
