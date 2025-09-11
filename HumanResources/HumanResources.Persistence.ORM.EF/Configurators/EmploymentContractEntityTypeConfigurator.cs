using Microsoft.EntityFrameworkCore;
using MOROPO.Framework.Decisor.HumanResources.Persistence.Entities.Contract;

namespace MOROPO.Framework.Decisor.HumanResources.Persistence.ORM.EF.Configurators
{
    public class EmploymentContractEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractEntityTypeConfigurator<AbstractEmploymentContract>
	{
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<AbstractEmploymentContract> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasIndex(entity => new { entity.Id, entity.Year }).IsUnique();
        }
    }
}

