using Microsoft.EntityFrameworkCore;

namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.ORM.EF.Repositories
{
    public class ProgramRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.Program, System.Guid>
    {
        public ProgramRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Entities.Program> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.Chief).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.Manager).ThenInclude(entity => entity.BusinessKind)
                .Include(entity => entity.Manager).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.ExpectResults);
        }
    }
}
