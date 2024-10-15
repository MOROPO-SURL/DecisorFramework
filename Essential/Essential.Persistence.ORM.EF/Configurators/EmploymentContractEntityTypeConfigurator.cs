namespace MOROPO.Framework.Decisor.Essential.Persistence.ORM.EF.Configurators
{
	public class EmploymentContractEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractEntityTypeConfigurator<Entities.EmploymentContract>
	{
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.EmploymentContract> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasKey(entity => new { entity.Number, entity.Year });
        }
    }
}

