namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class PublicationResultResearcherBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<PublicationResult, System.Guid, Contract.AbstractResearcher, System.Guid>
    {
        public System.Guid ProwId { get ; set ; }
        public PublicationResult Prow { get ; set ; }
        
        public System.Guid SternId { get ; set ; }
        public Contract.AbstractResearcher Stern { get ; set ; }
    }
}
