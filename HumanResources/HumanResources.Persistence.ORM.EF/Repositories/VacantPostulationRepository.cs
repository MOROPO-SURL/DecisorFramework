using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.HumanResources.Persistence.ORM.EF.Repositories
{
    public class VacantPostulationRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.VacantPostulation, System.Guid>
    {
        public VacantPostulationRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Entities.VacantPostulation> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.Staff).ThenInclude(entity => entity.Structure).ThenInclude(entity => entity.Identity)
                .Include(entity => entity.Vacant).ThenInclude(entity => entity.WorkPosition)
                .Include(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.PostalContactItemBridges).ThenInclude(bridge => bridge.Stern).ThenInclude(entity => entity.Location)
                .Include(entity => entity.OfficialPostalContactItem).ThenInclude(entity => entity.Location)
                .Include(entity => entity.AlternativePostalContactItem).ThenInclude(entity => entity.Location)
                .Include(entity => entity.DocumentBridges).ThenInclude(bridge => bridge.Stern);
        }
    }
}
