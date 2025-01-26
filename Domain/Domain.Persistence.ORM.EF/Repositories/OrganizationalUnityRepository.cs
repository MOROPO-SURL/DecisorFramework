namespace MOROPO.Framework.Decisor.Domain.Persistence.ORM.EF.Repositories
{
    public class OrganizationalUnityRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.OrganizationalUnity, System.Guid>
    {
        public OrganizationalUnityRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }
    }
}
