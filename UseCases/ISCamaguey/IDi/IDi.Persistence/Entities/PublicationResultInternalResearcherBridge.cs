namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class PublicationResultInternalResearcherBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<PublicationResult, System.Guid, InternalResearcher, System.Guid>
    {
        public System.Guid ProwId { get ; set ; }
        public PublicationResult Prow { get ; set ; }
        
        public System.Guid SternId { get ; set ; }
        public InternalResearcher Stern { get ; set ; }

        public bool IsPrincipalAuthor { get ; set ; }
    }
}
