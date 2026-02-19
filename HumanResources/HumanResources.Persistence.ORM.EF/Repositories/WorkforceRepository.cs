using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.HumanResources.Persistence.ORM.EF.Repositories
{
    public class WorkforceRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.Workforce, System.Guid>
    {
        public WorkforceRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Entities.Workforce> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .AsNoTracking()
                .Include(entity => entity.ChiefVacant).ThenInclude(entity => entity.WorkPosition)
                .Include(entity => entity.ChiefVacant).ThenInclude(entity => entity.SalaryStandard)
                .Include(entity => entity.OrganizationalUnities).ThenInclude(entity => entity.OrganizationalUnity)
                .Include(entity => entity.OrganizationalUnities).ThenInclude(entity => entity.ChiefVacant).ThenInclude(entity => entity.WorkPosition)
                .Include(entity => entity.OrganizationalUnities).ThenInclude(entity => entity.ChiefVacant).ThenInclude(entity => entity.SalaryStandard)
                .AsSplitQuery();
        }
    }
}