using MOROPO.Framework.Decisor.Core.Persistence.ORM.EF.Configurators.Base;

namespace MOROPO.Framework.Decisor.Financial.Persistence.ORM.EF.Providers
{
	public class FinantialDbSchemaConfigurationProvider : Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade
    {
        public System.Collections.Generic.ICollection<Guama.Core.Persistence.ORM.EF.Configurators.Contract.IEntityTypeConfigurator> EntityTypeConfigurators
        {
            get
            {
                return new System.Collections.Generic.List<Guama.Core.Persistence.ORM.EF.Configurators.Contract.IEntityTypeConfigurator>
                {
                    new BaseEntityTypeConfigurator<Entities.BankAccount>(),
                    new BaseEntityTypeConfigurator<Entities.BankAgency>(),
                    new BaseEntityTypeConfigurator<Entities.BankBranch>(),
                    new BaseEntityTypeConfigurator<Entities.Contract.AbstractCashAdvance>(),
                    new BaseEntityTypeConfigurator<Entities.CostCenter>()
                };
            }
        }

        public string DefaultPersistenceSchema => "decisorframework_finantial";
    }
}

