namespace MOROPO.Framework.Decisor.HumanResources.Persistence.ORM.EF.Configurators
{
    public class WorkforceOrganizationalUnityVacantBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractEntityTypeConfigurator<Entities.WorkforceOrganizationalUnityVacantBridge>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entities.WorkforceOrganizationalUnityVacantBridge> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasKey(bridge => new { bridge.WorkforceId, bridge.OrganizationUnityId, bridge.VacantId });

            entityTypeBuilder.HasOne(bridge => bridge.Workforce).WithMany(entity => entity.OrganizationalUnityVacantBridges).HasForeignKey(bridge => bridge.WorkforceId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
            entityTypeBuilder.HasOne(bridge => bridge.OrganizationUnity).WithMany().HasForeignKey(bridge => bridge.OrganizationUnityId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
            entityTypeBuilder.HasOne(bridge => bridge.Vacant).WithMany().HasForeignKey(bridge => bridge.VacantId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
