namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class PublicationResultExternalResearcherBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<PublicationResult, System.Guid, ExternalResearcher, System.Guid>
    {
        public System.Guid ProwId { get ; set ; }
        public PublicationResult Prow { get ; set ; }
        
        public System.Guid SternId { get ; set ; }
        public ExternalResearcher Stern { get ; set ; }

        public bool IsPrincipalAuthor { get; set; }
    }
}
