namespace MOROPO.Framework.Decisor.Commercial.Persistence.ORM.EF.Configurators
{
    public class LegalClientEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractEntityTypeConfigurator<Entities.LegalClient>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.LegalClient> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasOne(entity => entity.Contact).WithOne().HasForeignKey<Entities.LegalClient>(entity => entity.ContactId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
        }
    }
}

