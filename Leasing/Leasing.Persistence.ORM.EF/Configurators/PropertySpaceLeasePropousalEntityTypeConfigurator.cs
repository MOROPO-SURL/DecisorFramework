namespace MOROPO.Framework.Decisor.Leasing.Persistence.ORM.EF.Configurators
{
    public class PropertySpaceLeasePropousalEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractEntityTypeConfigurator<Entities.PropertySpaceLeasePropousal>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.PropertySpaceLeasePropousal> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasIndex(entity => new { entity.PropertyLeasePropousalId, entity.PropertySpaceId }).IsUnique();
        }
    }
}
