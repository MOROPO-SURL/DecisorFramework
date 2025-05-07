using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.Commercial.Persistence.ORM.EF.Repositories
{
    public class NaturalProviderRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.NaturalProvider, System.Guid>
    {
        public NaturalProviderRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Entities.NaturalProvider> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.Contact).ThenInclude(entity => entity.BusinessKind)
                .Include(entity => entity.DefaultPaymentTerm)
                .Include(entity => entity.BankAccountBridges).ThenInclude(bridge => bridge.Stern).ThenInclude(entity => entity.Branch).ThenInclude(entity => entity.Agency)
                .Include(entity => entity.BankAccountBridges).ThenInclude(bridge => bridge.Stern).ThenInclude(entity => entity.Currency)
                .Include(entity => entity.DocumentBridges).ThenInclude(bridge => bridge.Stern);
        }
    }
}

