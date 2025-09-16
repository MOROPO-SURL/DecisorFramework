namespace MOROPO.Framework.Decisor.Leasing.Persistence.ORM.EF.Configurators
{
    public class NaturalClientPropertyLeasingPersonContactBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.NaturalClientPropertyLeasingPersonContactBridge, Entities.NaturalClientPropertyLeasing, System.Guid, Domain.Persistence.Entities.PersonContact, System.Guid>
    {
        public NaturalClientPropertyLeasingPersonContactBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.ContactBridges;
        }
    }
}
