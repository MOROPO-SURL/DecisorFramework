namespace MOROPO.Framework.Decisor.HumanResources.Persistence.ORM.EF.Repositories
{
    public class SalaryStandardRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Persistence.Entities.SalaryStandard, System.Guid>
    {
        public SalaryStandardRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }
    }
}
