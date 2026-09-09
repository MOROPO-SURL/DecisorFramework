using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract;
using MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.Lab.Persistence.ORM.EF.Configurators;

public sealed class WorkPlanEntityTypeConfigurator : AbstractEntityTypeConfigurator<Entities.WorkPlan>
{
    protected override void ApplayRules(EntityTypeBuilder<WorkPlan> entityTypeBuilder)
    {
        base.ApplayRules(entityTypeBuilder);

        entityTypeBuilder.HasOne(entity => entity.WorkingGroup).WithMany().HasForeignKey(entity => entity.WorkingGroupId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
    }
}
