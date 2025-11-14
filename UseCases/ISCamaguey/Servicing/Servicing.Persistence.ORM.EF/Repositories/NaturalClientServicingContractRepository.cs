using Microsoft.EntityFrameworkCore;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.ORM.EF.Repositories
{
    public class NaturalClientServicingContractRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.NaturalClientServicingContract, int>
    {
        public NaturalClientServicingContractRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}