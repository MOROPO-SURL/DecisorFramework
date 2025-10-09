namespace MOROPO.Framework.Decisor.HumanResources.Persistence.ORM.EF.Repositories
{
    public class EmployeeDailyCheckingRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.EmployeeDailyChecking, long>
    {
        public EmployeeDailyCheckingRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }
    }
}
