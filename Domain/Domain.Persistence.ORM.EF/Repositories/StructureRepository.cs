using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.Domain.Persistence.ORM.EF.Repositories
{
    public class StructureRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.Structure, System.Guid>
    {
        public StructureRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Entities.Structure> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.Kind)
                .Include(entity => entity.OrganizationalUnityBridges).ThenInclude(bridge => bridge.Stern);
        }
    }
}
