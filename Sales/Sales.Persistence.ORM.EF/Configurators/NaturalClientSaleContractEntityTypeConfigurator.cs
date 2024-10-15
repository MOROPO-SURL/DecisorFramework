namespace MOROPO.Framework.Decisor.Sales.Persistence.ORM.EF.Configurators
{
	public class NaturalClientSaleContractEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractEntityTypeConfigurator<Entities.NaturalClientSaleContract>
	{
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.NaturalClientSaleContract> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasKey(entity => new { entity.Number, entity.Year });
        }
    }
}

