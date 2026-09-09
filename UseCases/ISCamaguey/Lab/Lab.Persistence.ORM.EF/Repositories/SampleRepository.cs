using Microsoft.EntityFrameworkCore;
using MOROPO.Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract;
using MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities.Contract;

namespace MOROPO.ISCamaguey.Decisor.Lab.Persistence.ORM.EF.Repositories;

public sealed class SampleRepository : AbstractEntityRepository<AbstractSample, System.Guid>
{
    public SampleRepository(DbContext dbContext) : base(dbContext)
    {
    }
}