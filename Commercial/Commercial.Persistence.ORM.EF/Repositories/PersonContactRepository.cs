using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.Commercial.Persistence.ORM.EF.Repositories
{
    public class PersonContactRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.PersonContact, System.Guid>
    {
        public PersonContactRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Entities.PersonContact> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.BusinessKind);
        }
    }
}
