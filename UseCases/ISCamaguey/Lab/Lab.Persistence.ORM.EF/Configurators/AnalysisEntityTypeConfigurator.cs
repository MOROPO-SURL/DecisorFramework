namespace MOROPO.ISCamaguey.Decisor.Lab.Persistence.ORM.EF.Configurators;

internal sealed class AnalysisEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractEntityTypeConfigurator<Entities.Analysis>
{
    protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.Analysis> entityTypeBuilder)
    {
        base.ApplayRules(entityTypeBuilder);

        entityTypeBuilder.HasOne(entity => entity.Sample).WithMany().HasForeignKey(entity => entity.SampleId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        entityTypeBuilder.HasOne(entity => entity.WorkPlan).WithMany().HasForeignKey(entity => entity.WorkPlanId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        entityTypeBuilder.HasOne(entity => entity.Author).WithMany().HasForeignKey(entity => entity.AuthorId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        entityTypeBuilder.HasOne(entity => entity.Technique).WithMany().HasForeignKey(entity => entity.TechniqueId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
    }
}