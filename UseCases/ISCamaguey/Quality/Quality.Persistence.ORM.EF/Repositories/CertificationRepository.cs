using Microsoft.EntityFrameworkCore;

namespace MOROPO.ISCamaguey.Decisor.Quality.Persistence.ORM.EF.Repositories
{
    public class CertificationRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.Certification, System.Guid>
    {
        public CertificationRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Entities.Certification> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.CubanStandardBridges).ThenInclude(bridge => bridge.Stern)
                .Include(entity => entity.IsoStandardBridges).ThenInclude(bridge => bridge.Stern);
        }
    }
}