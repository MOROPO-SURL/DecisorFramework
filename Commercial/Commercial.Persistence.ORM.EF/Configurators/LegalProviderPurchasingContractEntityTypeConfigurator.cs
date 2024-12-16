namespace MOROPO.Framework.Decisor.Commercial.Persistence.ORM.EF.Configurators
{
    public class LegalProviderPurchasingContractEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractEntityTypeConfigurator<Entities.LegalProviderPurchasingContract>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.LegalProviderPurchasingContract> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasKey(entity => new { entity.Number, entity.Year });
        }
    }
}

