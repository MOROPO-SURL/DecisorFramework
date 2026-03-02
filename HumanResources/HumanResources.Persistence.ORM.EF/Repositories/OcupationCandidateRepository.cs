using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.HumanResources.Persistence.ORM.EF.Repositories
{
    public class OcupationCandidateRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.OcupationCandidate, System.Guid>
    {
        public OcupationCandidateRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Entities.OcupationCandidate> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(entity => entity.Postulation).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.Postulation).ThenInclude(entity => entity.Vacant).ThenInclude(entity => entity.WorkPosition)
                .Include(entity => entity.Postulation).ThenInclude(entity => entity.Vacant).ThenInclude(entity => entity.WorkforceOrganizationalUnit).ThenInclude(entity => entity.OrganizationalStructuringUnit).ThenInclude(entity => entity.OrganizationalUnit)
                .Include(entity => entity.Postulation).ThenInclude(entity => entity.Staff).ThenInclude(entity => entity.AdministrativeEntity).ThenInclude(entity => entity.Identity)
                .Include(entity => entity.Responsible).ThenInclude(entity => entity.Contact).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
                .Include(entity => entity.RawMedicalCheckDocument)
                .Include(entity => entity.RawPhysicologicalCheckDocument)
                .Include(entity => entity.RawDefenseStatusCheckDocument)
                .Include(entity => entity.RawResearchResultDocument)
                .Include(entity => entity.RawModelDocument)
                .AsNoTracking()
                .AsSplitQuery();
        }
    }
}
