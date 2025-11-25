using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.ORM.EF.Repositories
{
    public class NaturalClientServicingContractRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.NaturalClientServicingContract, System.Guid>
    {
        public NaturalClientServicingContractRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<Entities.NaturalClientServicingContract> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.PaymentTerm)
                .Include(entity => entity.BankAccount).ThenInclude(entity => entity.Branch).ThenInclude(entity => entity.Agency)
                .Include(entity => entity.BankAccount).ThenInclude(entity => entity.Currency)
                .Include(entity => entity.Client).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.Client).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.BusinessKind)
                .Include(entity => entity.Document)
                .Include(entity => entity.TrainingServiceBridges).ThenInclude(bridge => bridge.Stern)
                .Include(entity => entity.SampleAnalysisServiceBridges).ThenInclude(bridge => bridge.Stern).ThenInclude(entity => entity.SampleKind)
                .Include(entity => entity.GroundIntegralStudyServiceBridges).ThenInclude(bridge => bridge.Stern);
        }
    }
}