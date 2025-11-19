namespace MOROPO.Framework.Decisor.Leasing.Persistence.ORM.EF.Configurators
{
    public class NaturalClientPropertyLeaseContractSpaceBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.NaturalClientPropertyLeaseContractSpaceBridge, Entities.NaturalClientPropertyLeaseContract, System.Guid, Domain.Persistence.Entities.PropertySpace, System.Guid>
    {
        public NaturalClientPropertyLeaseContractSpaceBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.SpaceBridges;
        }
    }
}
