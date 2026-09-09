namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class ThesisResultInternalResearcherBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<ThesisResult, System.Guid, InternalResearcher, System.Guid>
    {
        public System.Guid ProwId { get ; set ; }
        public ThesisResult Prow { get ; set ; }
        
        public System.Guid SternId { get ; set ; }
        public InternalResearcher Stern { get ; set ; }

        public bool IsPrincipalAuthor { get; set; }
    }
}
