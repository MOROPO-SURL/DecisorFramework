using System.Linq;
using Microsoft.EntityFrameworkCore;
using MOROPO.Framework.Decisor.Purchasing.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Purchasing.Persistence.ORM.EF.Repositories
{
	public class LegalProviderRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.LegalProvider, System.Guid>
	{
		public LegalProviderRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
		{
		}

        protected override IQueryable<LegalProvider> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.BusinessKind);
        }
    }
}
