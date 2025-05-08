using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.Commercial.Persistence.ORM.EF.Repositories
{
    public class NaturalClientRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.NaturalClient, System.Guid>
    {
        public NaturalClientRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Entities.NaturalClient> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.DefaultPaymentTerm)
                .Include(entity => entity.BankAccountBridges).ThenInclude(bridge => bridge.Stern).ThenInclude(entity => entity.Branch).ThenInclude(entity => entity.Agency)
                .Include(entity => entity.BankAccountBridges).ThenInclude(bridge => bridge.Stern).ThenInclude(entity => entity.Currency)
                .Include(entity => entity.DocumentBridges).ThenInclude(bridge => bridge.Stern);
        }
    }
}

