using Microsoft.EntityFrameworkCore;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.ORM.EF.Repositories
{
    public class TrainingServiceRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.TrainingService, System.Guid>
    {
        public TrainingServiceRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Entities.TrainingService> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.DocumentBridges).ThenInclude(bridge => bridge.Stern);
        }
    }
}
