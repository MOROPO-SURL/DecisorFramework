namespace MOROPO.Framework.Decisor.Purchasing.Persistence.ORM.EF.Configurators
{
    public class LegalProviderBudgetEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractEntityTypeConfigurator<Entities.LegalProviderBudget>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.LegalProviderBudget> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasIndex(entity => new { entity.Number, entity.Year, entity.ProviderId }).IsUnique();
        }
    }
}

