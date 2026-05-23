using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract;
using MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.ORM.EF.Configurators;

public sealed class ProjectSpecificObjectiveEntityTypeConfigurator : AbstractEntityTypeConfigurator<ProjectSpecificObjective>
{
    protected override void ApplayRules(EntityTypeBuilder<ProjectSpecificObjective> entityTypeBuilder)
    {
        base.ApplayRules(entityTypeBuilder);

        entityTypeBuilder.HasIndex(entity => new { entity.Index, entity.ProjectId }).IsUnique();
    }
}
