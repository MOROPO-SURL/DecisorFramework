namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.ORM.EF.Configurators
{
    public class ProgramExpectResultEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractEntityTypeConfigurator<Entities.ProgramExpectResult>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.ProgramExpectResult> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasIndex(entity => entity.Index).IsUnique();
        }
    }
}
