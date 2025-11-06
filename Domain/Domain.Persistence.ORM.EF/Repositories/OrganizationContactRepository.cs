using Microsoft.EntityFrameworkCore;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Domain.Persistence.ORM.EF.Repositories;

public class OrganizationContactRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<OrganizationContact, System.Guid>
{
    public OrganizationContactRepository(DbContext dbContext) : base(dbContext)
    {
    }

    protected override System.Linq.IQueryable<OrganizationContact> GetQueryableDbSet()
    {
        return base.GetQueryableDbSet()
            .Include(entity => entity.Identity).ThenInclude(entity => entity.Image)
            .Include(entity => entity.Identity).ThenInclude(entity => entity.PostalContactItemBridges).ThenInclude(bridge => bridge.Stern).ThenInclude(entity => entity.Location)
            .Include(entity => entity.Identity).ThenInclude(entity => entity.PhoneContactItemBridges).ThenInclude(bridge => bridge.Stern)
            .Include(entity => entity.Identity).ThenInclude(entity => entity.EmailContactItemBridges).ThenInclude(bridge => bridge.Stern)
            .Include(entity => entity.Identity).ThenInclude(entity => entity.WebSiteContactItemBridges).ThenInclude(bridge => bridge.Stern)
            .Include(entity => entity.CentralStateStructure)
            .Include(entity => entity.Representative).ThenInclude(entity => entity.Identity).ThenInclude(entity => entity.Image)
            .Include(entity => entity.MainPostalContact).ThenInclude(entity => entity.Location)
            .Include(entity => entity.BusinessKind);
    }
}
