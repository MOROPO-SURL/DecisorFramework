using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.Commercial.Persistence.ORM.EF.Repositories
{
    public class OrganizationContactRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.OrganizationContact, System.Guid>
    {
        public OrganizationContactRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Entities.OrganizationContact> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.BusinessKind);
        }
    }
}
