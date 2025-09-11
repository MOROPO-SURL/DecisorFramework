namespace MOROPO.Framework.Decisor.Leasing.Persistence.ORM.EF.Configurators
{
    public class NaturalClientPropertyLeasingCompensationDocumentBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.NaturalClientPropertyLeasingCompensationDocumentBridge, Entities.NaturalClientPropertyLeasingCompensation, System.Guid, Guama.Media.Persistence.Entities.Document, System.Guid>
    {
        public NaturalClientPropertyLeasingCompensationDocumentBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.DocumentBridges;
        }
    }
}
