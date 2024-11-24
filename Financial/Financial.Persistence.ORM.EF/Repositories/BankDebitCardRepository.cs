namespace MOROPO.Framework.Decisor.Financial.Persistence.ORM.EF.Repositories
{
    public class BankDebitCardRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.BankDebitCard, string>
    {
        public BankDebitCardRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }
    }
}
