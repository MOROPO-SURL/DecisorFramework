namespace MOROPO.ISCamaguey.Decisor.Lab.Persistence.ORM.EF.Configurators;

internal sealed class AnalysisQualityCheckEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractEntityTypeConfigurator<Entities.AnalysisQualityCheck>
{
    protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.AnalysisQualityCheck> entityTypeBuilder)
    {
        base.ApplayRules(entityTypeBuilder);

        entityTypeBuilder.HasOne(entity => entity.Analysis).WithMany().HasForeignKey(entity => entity.AnalysisId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        entityTypeBuilder.HasOne(entity => entity.Author).WithMany().HasForeignKey(entity => entity.AuthorId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
    }
}
