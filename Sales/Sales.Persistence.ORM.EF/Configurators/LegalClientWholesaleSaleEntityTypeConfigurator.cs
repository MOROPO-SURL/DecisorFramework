namespace MOROPO.Framework.Decisor.Sales.Persistence.ORM.EF.Configurators
{
	public class LegalClientWholesaleSaleEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractEntityTypeConfigurator<Entities.LegalClientWholesaleSale>
	{
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.LegalClientWholesaleSale> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasOne(entity => entity.Contract).WithMany().HasForeignKey(entity => new { entity.ContractNumber, entity.ContractYear });
        }
    }
}

