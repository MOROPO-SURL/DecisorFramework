using Microsoft.EntityFrameworkCore;
using MOROPO.Framework.Decisor.Financial.Persistence.Entities;
using System.Linq;

namespace MOROPO.Framework.Decisor.Financial.Persistence.ORM.EF.Repositories
{
    public class BankAgencyRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.BankAgency, System.Guid>
    {
        public BankAgencyRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<BankAgency> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet().Include(entity => entity.Image);
        }
    }
}
