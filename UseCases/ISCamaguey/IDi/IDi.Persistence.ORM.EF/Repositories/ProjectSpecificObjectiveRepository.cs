using MOROPO.Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract;
using MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.ORM.EF.Repositories;

public sealed class ProjectSpecificObjectiveRepository : AbstractEntityRepository<ProjectSpecificObjective, System.Guid>
{
    public ProjectSpecificObjectiveRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
    {
    }
}
