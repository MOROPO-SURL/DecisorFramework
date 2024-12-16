namespace MOROPO.Framework.Decisor.Commercial.Persistence.ORM.EF.Configurators
{
    public class LegalProviderEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractEntityTypeConfigurator<Entities.LegalProvider>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.LegalProvider> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasOne(entity => entity.Contact).WithOne().HasForeignKey<Entities.LegalProvider>(entity => entity.ContactId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
        }
    }
}

