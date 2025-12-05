namespace MOROPO.Framework.Decisor.Leasing.Persistence.ORM.EF.Configurators
{
    public class LegalClientPropertyLeaseContractSpaceBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.LegalClientPropertyLeaseContractSpaceBridge, Entities.LegalClientPropertyLeaseContract, System.Guid, Domain.Persistence.Entities.PropertySpace, System.Guid>
    {
        public LegalClientPropertyLeaseContractSpaceBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.SpaceBridges;
        }
    }
}
