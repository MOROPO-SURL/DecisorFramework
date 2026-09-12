namespace MOROPO.ISCamaguey.Decisor.Lab.Persistence.ORM.EF.Configurators;

internal sealed class AssessmentQualityCheckEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractEntityTypeConfigurator<Entities.AssessmentQualityCheck>
{
    protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.AssessmentQualityCheck> entityTypeBuilder)
    {
        base.ApplayRules(entityTypeBuilder);

        entityTypeBuilder.HasOne(entity => entity.Assessment).WithMany().HasForeignKey(entity => entity.AssessmentId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        entityTypeBuilder.HasOne(entity => entity.Author).WithMany().HasForeignKey(entity => entity.AuthorId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
    }
}