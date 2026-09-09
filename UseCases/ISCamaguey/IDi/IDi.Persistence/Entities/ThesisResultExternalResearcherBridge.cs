namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class ThesisResultExternalResearcherBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<ThesisResult, System.Guid, ExternalResearcher, System.Guid>
    {
        public System.Guid ProwId { get ; set ; }
        public ThesisResult Prow { get ; set ; }
        
        public System.Guid SternId { get ; set ; }
        public ExternalResearcher Stern { get ; set ; }

        public bool IsPrincipalAuthor { get; set; }
    }
}
