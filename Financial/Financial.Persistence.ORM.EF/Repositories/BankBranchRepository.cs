using Microsoft.EntityFrameworkCore;
using MOROPO.Framework.Decisor.Financial.Persistence.Entities;
using System.Linq;

namespace MOROPO.Framework.Decisor.Financial.Persistence.ORM.EF.Repositories
{
    public class BankBranchRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.BankBranch, System.Guid>
    {
        public BankBranchRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<BankBranch> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet().Include(entity => entity.Agency).ThenInclude(entity => entity.Image);
        }
    }
}
