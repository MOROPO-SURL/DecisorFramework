namespace MOROPO.ISCamaguey.Decisor.Lab.Persistence.ORM.EF.Configurators;

internal sealed class AssessmentEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractEntityTypeConfigurator<Entities.Assessment>
{
    protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.Assessment> entityTypeBuilder)
    {
        base.ApplayRules(entityTypeBuilder);

        entityTypeBuilder.HasOne(entity => entity.Sample).WithOne().HasForeignKey<Entities.Assessment>(entity => entity.SampleId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        entityTypeBuilder.HasOne(entity => entity.WorkPlan).WithMany().HasForeignKey(entity => entity.WorkPlanId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        entityTypeBuilder.HasOne(entity => entity.Author).WithMany().HasForeignKey(entity => entity.AuthorId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
    }
}