namespace MOROPO.Framework.Decisor.Commercial.Persistence.ORM.EF.Configurators
{
    public class NaturalProviderEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractEntityTypeConfigurator<Entities.NaturalProvider>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.NaturalProvider> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasOne(entity => entity.Contact).WithOne().HasForeignKey<Entities.NaturalProvider>(entity => entity.ContactId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
        }
    }
}

