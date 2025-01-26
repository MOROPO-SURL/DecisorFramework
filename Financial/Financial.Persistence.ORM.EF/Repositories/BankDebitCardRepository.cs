using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.Financial.Persistence.ORM.EF.Repositories
{
    public class BankDebitCardRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.BankDebitCard, System.Guid>
    {
        public BankDebitCardRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Entities.BankDebitCard> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.BankAccount).ThenInclude(entity => entity.Branch).ThenInclude(entity => entity.Agency)
                .Include(entity => entity.BankAccount).ThenInclude(entity => entity.Currency);
        }
    }
}
