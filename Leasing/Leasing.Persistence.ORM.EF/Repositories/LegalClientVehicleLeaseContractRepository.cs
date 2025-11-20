using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.Leasing.Persistence.ORM.EF.Repositories
{
    public class LegalClientVehicleLeaseContractRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.LegalClientVehicleLeaseContract, System.Guid>
    {
        public LegalClientVehicleLeaseContractRepository(DbContext dbContext) : base(dbContext)
        {
        }

        //protected override System.Linq.IQueryable<Entities.LegalClientVehicleLeaseContract> GetQueryableDbSet()
        //{
        //    return base.GetQueryableDbSet()
        //        .Include(entity => entity.Client).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
        //        .Include(entity => entity.Postulation).ThenInclude(entity => entity.Offer).ThenInclude(entity => entity.Propousal).ThenInclude(entity => entity.Vehicle).ThenInclude(entity => entity.FeatureImage);
        //}
    }
}
