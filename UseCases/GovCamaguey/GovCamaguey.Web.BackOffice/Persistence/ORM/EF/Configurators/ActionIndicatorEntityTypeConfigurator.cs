namespace MOROPO.GovCamaguey.Decisor.Prototype.Web.BackOffice.Persistence.ORM.EF.Configurators;

public sealed class ActionIndicatorEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractEntityTypeConfigurator<Prototype.Persistence.Entities.ActionIndicator>
{
    protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Prototype.Persistence.Entities.ActionIndicator> entityTypeBuilder)
    {
        base.ApplayRules(entityTypeBuilder);

        entityTypeBuilder.HasOne(entity => entity.UnitMeasurement).WithMany().HasForeignKey(entity => entity.UnitMeasurementId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
    }
}
