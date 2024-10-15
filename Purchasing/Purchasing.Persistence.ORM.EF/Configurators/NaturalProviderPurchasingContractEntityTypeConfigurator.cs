namespace MOROPO.Framework.Decisor.Purchasing.Persistence.ORM.EF.Configurators
{
	public class NaturalProviderPurchasingContractEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractEntityTypeConfigurator<Entities.NaturalProviderPurchasingContract>
	{
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.NaturalProviderPurchasingContract> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasKey(entity => new { entity.Number, entity.Year });
        }
    }
}

