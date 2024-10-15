namespace MOROPO.Framework.Decisor.Sales.Persistence.ORM.EF.Configurators
{
	public class NaturalClientWholesaleSaleEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractEntityTypeConfigurator<Entities.NaturalClientWholesaleSale>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.NaturalClientWholesaleSale> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasOne(entity => entity.Contract).WithMany().HasForeignKey(entity => new { entity.ContractNumber, entity.ContractYear });
        }
    }
}

