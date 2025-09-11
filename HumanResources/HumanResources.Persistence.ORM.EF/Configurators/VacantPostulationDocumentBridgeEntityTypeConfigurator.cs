namespace MOROPO.Framework.Decisor.HumanResources.Persistence.ORM.EF.Configurators
{
    public class VacantPostulationDocumentBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.VacantPostulationDocumentBridge, Entities.VacantPostulation, System.Guid, Guama.Media.Persistence.Entities.Document, System.Guid>
    {
        public VacantPostulationDocumentBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.DocumentBridges;
        }
    }
}
