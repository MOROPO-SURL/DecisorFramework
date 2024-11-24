namespace MOROPO.Framework.Decisor.Financial.Persistence.ORM.EF.Repositories
{
    public class CurrencyRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.Currency, System.Guid>
    {
        public CurrencyRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }
    }
}
