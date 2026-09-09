namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.ORM.EF.Repositories;

public class ProgramKindRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Entities.ProgramKind, System.Guid>
{
    public ProgramKindRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
    {
    }
}
