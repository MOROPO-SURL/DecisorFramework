namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class TrainingResultInternalResearcherBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<TrainingResult, System.Guid, InternalResearcher, System.Guid>
    {
        public System.Guid ProwId { get ; set ; }
        public TrainingResult Prow { get ; set ; }
        
        public System.Guid SternId { get ; set ; }
        public InternalResearcher Stern { get ; set ; }
    }
}
