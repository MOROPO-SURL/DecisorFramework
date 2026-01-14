namespace MOROPO.Framework.Decisor.HumanResources.Persistence.ORM.EF.Repositories;

public class EmploymentContractRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.Contract.AbstractEmploymentContract, System.Guid>
{
    public EmploymentContractRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
    {
    }
}