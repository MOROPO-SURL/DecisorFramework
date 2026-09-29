using MOROPO.Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract;
using MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.ORM.EF.Repositories;

public sealed class ScientificTechnicalResultKindRepository : AbstractEntityRepository<ScientificTechnicalResultKind, System.Guid>
{
    public ScientificTechnicalResultKindRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
    {
    }
}