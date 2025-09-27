namespace MOROPO.ISCamaguey.Decisor.Quality.Persistence.ORM.EF.Repositories
{
    public class IsoStandardRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.IsoStandard, int>
    {
        public IsoStandardRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }
    }
}
