namespace MOROPO.Framework.Decisor.Commercial.Persistence.ORM.EF.Configurators
{
    public class LegalContactEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractEntityTypeConfigurator<Entities.LegalContact>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.LegalContact> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasOne(entity => entity.Identity).WithOne().HasForeignKey<Entities.LegalContact>(entity => entity.IdentityId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
        }
    }
}
