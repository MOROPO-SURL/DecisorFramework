using Microsoft.EntityFrameworkCore;
using MOROPO.Framework.Decisor.Governance.Persistence.Entities;
using System.Linq;

namespace MOROPO.Framework.Decisor.Governance.Persistence.ORM.EF.Repositories
{
    public class AgreementRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.Agreement, System.Guid>
    {
        public AgreementRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<Agreement> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.Responsible).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.Meeting).ThenInclude(entity => entity.DecisionMakingGroup).ThenInclude(entity => entity.AdministrativeEntity).ThenInclude(entity => entity.Identity);
        }
    }
}
