using Microsoft.EntityFrameworkCore;
using MOROPO.Framework.Decisor.Financial.Persistence.Entities;
using System.Linq;

namespace MOROPO.Framework.Decisor.Financial.Persistence.ORM.EF.Repositories
{
    public class BankAccountRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.BankAccount, System.Guid>
    {
        public BankAccountRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<BankAccount> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet().Include(entity => entity.Branch).ThenInclude(entity => entity.Agency).ThenInclude(entity => entity.Image);
        }
    }
}
