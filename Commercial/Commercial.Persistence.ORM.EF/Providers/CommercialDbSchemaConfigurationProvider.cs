using MOROPO.Framework.Decisor.Core.Persistence.ORM.EF.Configurators.Base;

namespace MOROPO.Framework.Decisor.Commercial.Persistence.ORM.EF.Providers
{
    public class CommercialDbSchemaConfigurationProvider : Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade
    {
        public System.Collections.Generic.ICollection<Guama.Core.Persistence.ORM.EF.Configurators.Contract.IEntityTypeConfigurator> EntityTypeConfigurators
        {
            get
            {
                return new Guama.Core.Persistence.ORM.EF.Configurators.Contract.IEntityTypeConfigurator[]
                {
                    new BaseEntityTypeConfigurator<Entities.LegalBusinessKind>(),
                    new BaseEntityTypeConfigurator<Entities.NaturalBusinessKind>(),
                    new BaseEntityTypeConfigurator<Entities.RequestableService>(),
                    new BaseEntityTypeConfigurator<Entities.ProvisionableService>(),
                    new Configurators.BudgetEntityTypeConfigurator(),
                    new Configurators.BudgetProductBridgeEntityTypeConfigurator(),
                    new Configurators.BudgetServiceBridgeEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.Contract.AbstractContact>(),
                    new Configurators.LegalContactEntityTypeConfigurator(),
                    new Configurators.NaturalContactEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.ProductValueProposition>(),
                    new BaseEntityTypeConfigurator<Entities.ProductValuePropositionRate>(),
                    new Configurators.ProductValuePropositionImageBridgeEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.ServiceValueProposition>(),
                    new BaseEntityTypeConfigurator<Entities.ServiceValuePropositionRate>(),
                    new Configurators.ServiceValuePropositionImageBridgeEntityTypeConfigurator(),
                    new Configurators.LegalClientEntityTypeConfigurator(),
                    new Configurators.LegalClientSaleContractEntityTypeConfigurator(),
                    new Configurators.NaturalClientEntityTypeConfigurator(),
                    new Configurators.NaturalClientSaleContractEntityTypeConfigurator(),
                    new Configurators.LegalProviderEntityTypeConfigurator(),
                    new Configurators.LegalProviderPurchasingContractEntityTypeConfigurator(),
                    new Configurators.NaturalProviderEntityTypeConfigurator(),
                    new Configurators.NaturalProviderPurchasingContractEntityTypeConfigurator(),
                    new Configurators.BudgetEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.OrganizationContactBudget>(),
                    new BaseEntityTypeConfigurator<Entities.PersonContactBudget>()
                };
            }
        }

        public string DefaultPersistenceSchema => "decisorframework_commercial";
    }
}
