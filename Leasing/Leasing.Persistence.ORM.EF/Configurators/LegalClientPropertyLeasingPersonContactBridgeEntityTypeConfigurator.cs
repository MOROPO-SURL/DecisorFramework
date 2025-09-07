namespace MOROPO.Framework.Decisor.Leasing.Persistence.ORM.EF.Configurators
{
    public class LegalClientPropertyLeasingPersonContactBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.LegalClientPropertyLeasingPersonContactBridge, Entities.LegalClientPropertyLeasing, System.Guid, Domain.Persistence.Entities.PersonContact, System.Guid>
    {
        public LegalClientPropertyLeasingPersonContactBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.ContactBridges;
        }
    }
}
