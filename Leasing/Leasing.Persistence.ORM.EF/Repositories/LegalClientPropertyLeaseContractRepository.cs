using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.Leasing.Persistence.ORM.EF.Repositories
{
    public class LegalClientPropertyLeaseContractRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.LegalClientPropertyLeaseContract, System.Guid>
    {
        public LegalClientPropertyLeaseContractRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}