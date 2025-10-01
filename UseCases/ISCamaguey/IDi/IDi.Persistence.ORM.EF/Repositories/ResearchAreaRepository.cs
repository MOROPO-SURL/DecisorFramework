namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.ORM.EF.Repositories;

public class ResearchAreaRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.ResearchArea, System.Guid>
{
    public ResearchAreaRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
    {
    }
}
