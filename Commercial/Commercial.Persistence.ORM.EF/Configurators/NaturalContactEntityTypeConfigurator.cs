namespace MOROPO.Framework.Decisor.Commercial.Persistence.ORM.EF.Configurators
{
    public class NaturalContactEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractEntityTypeConfigurator<Entities.NaturalContact>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.NaturalContact> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasOne(entity => entity.Identity).WithOne().HasForeignKey<Entities.NaturalContact>(entity => entity.IdentityId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
        }
    }
}
