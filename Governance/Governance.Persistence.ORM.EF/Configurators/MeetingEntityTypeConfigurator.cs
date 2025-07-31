namespace MOROPO.Framework.Decisor.Governance.Persistence.ORM.EF.Configurators
{
    public class MeetingEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractEntityTypeConfigurator<Entities.Meeting>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.Meeting> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasIndex(entity => new { entity.Index, entity.DecisionMakingGroupId }).IsUnique();
        }
    }
}
