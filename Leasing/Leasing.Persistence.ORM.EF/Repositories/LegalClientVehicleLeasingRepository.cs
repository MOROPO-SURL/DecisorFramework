using Microsoft.EntityFrameworkCore;
using MOROPO.Framework.Decisor.Leasing.Persistence.Entities;
using System.Linq;

namespace MOROPO.Framework.Decisor.Leasing.Persistence.ORM.EF.Repositories
{
    public class LegalClientVehicleLeasingRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.LegalClientVehicleLeasing, System.Guid>
    {
        public LegalClientVehicleLeasingRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<LegalClientVehicleLeasing> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.Contract)
                .Include(entity => entity.ContactBridges).ThenInclude(entity => entity.Stern).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image);
        }
    }
}
