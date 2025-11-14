using Microsoft.EntityFrameworkCore;
using MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.ORM.EF.Repositories
{
    public class LegalClientServicingContractRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.LegalClientServicingContract, int>
    {
        public LegalClientServicingContractRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<LegalClientServicingContract> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.PaymentTerm)
                .Include(entity => entity.BankAccount).ThenInclude(entity => entity.Branch).ThenInclude(entity => entity.Agency)
                .Include(entity => entity.BankAccount).ThenInclude(entity => entity.Currency)
                .Include(entity => entity.Client).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.TrainingServiceBridges).ThenInclude(bridge => bridge.Stern)
                .Include(entity => entity.SampleAnalysisServiceBridges).ThenInclude(bridge => bridge.Stern)
                .Include(entity => entity.GroundIntegralStudyServiceBridges).ThenInclude(bridge => bridge.Stern);
        }
    }
}
