namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class ThesisResultResearcherBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<ThesisResult, System.Guid, Contract.AbstractResearcher, System.Guid>
    {
        public System.Guid ProwId { get ; set ; }
        public ThesisResult Prow { get ; set ; }
        
        public System.Guid SternId { get ; set ; }
        public Contract.AbstractResearcher Stern { get ; set ; }
    }
}
