namespace MOROPO.Framework.Decisor.Sales.Persistence.ORM.EF.Configurators
{
	public class BudgetEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractEntityTypeConfigurator<Entities.Contract.AbstractBudget>
	{
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.Contract.AbstractBudget> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasKey(entity => new { entity.Number, entity.Year });
        }
    }
}

