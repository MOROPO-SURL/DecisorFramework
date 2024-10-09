namespace MOROPO.Framework.Decisor.Core.Persistence.ORM.EF.Configurators
{
	public class NaturalProviderEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractEntityTypeConfigurator<Persistence.Entities.NaturalProvider>
	{
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.NaturalProvider> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasOne(entity => entity.Identity).WithOne().HasForeignKey<Persistence.Entities.NaturalProvider>(entity => entity.IdentityId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
        }
    }
}

