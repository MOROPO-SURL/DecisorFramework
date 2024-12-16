namespace MOROPO.Framework.Decisor.Domain.Persistence.ORM.EF.Configurators
{
    public class PropertyEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractEntityTypeConfigurator<Entities.Property>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.Property> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasIndex(entity => entity.PropertyRecordIdentifier).IsUnique();
        }
    }
}
