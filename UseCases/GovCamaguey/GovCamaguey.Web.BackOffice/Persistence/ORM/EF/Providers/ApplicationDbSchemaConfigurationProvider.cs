namespace MOROPO.GovCamaguey.Decisor.Prototype.Web.BackOffice.Persistence.ORM.EF.Providers
{
    public class ApplicationDbSchemaConfigurationProvider : Framework.Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade
    {
        public System.Collections.Generic.ICollection<Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.IEntityTypeConfigurator> EntityTypeConfigurators
        {
            get
            {
                return
                [
                    new Configurators.ObjectiveEntityTypeConfigurator(),
                    new Configurators.ProyectionEntityTypeConfigurator(),
                    new Configurators.ProyectionGuidelineBridgeEntityTypeConfigurator(),
                    new Configurators.ProyectionOrganizationResponsabilityBridgeEntityTypeConfigurator(),
                    new Configurators.ProyectionOrganizationParticipationBridgeEntityTypeConfigurator(),
                    new Configurators.ActionEntityTypeConfigurator(),
                    new Configurators.ActionOrganizationResponsabilityBridgeEntityTypeConfigurator(),
                    new Configurators.ActionOrganizationParticipationBridgeEntityTypeConfigurator()
                ];
            }
        }

        public string DefaultPersistenceSchema => null;
    }
}
