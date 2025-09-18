using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.Leasing.Persistence.ORM.EF.Repositories
{
    public class LegalClientVehicleLeasingRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.LegalClientVehicleLeasing, System.Guid>
    {
        public LegalClientVehicleLeasingRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Entities.LegalClientVehicleLeasing> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.Contract).ThenInclude(entity => entity.Client).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.Contract).ThenInclude(entity => entity.Postulation).ThenInclude(entity => entity.Offer).ThenInclude(entity => entity.Propousal).ThenInclude(entity => entity.Vehicle).ThenInclude(entity => entity.FeatureImage)
                .Include(entity => entity.Agreement)
                .Include(entity => entity.ContactBridges).ThenInclude(entity => entity.Stern).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image);
        }
    }
}
