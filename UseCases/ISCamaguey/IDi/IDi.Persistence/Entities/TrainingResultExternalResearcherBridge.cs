namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class TrainingResultExternalResearcherBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<TrainingResult, System.Guid, ExternalResearcher, System.Guid>
    {
        public System.Guid ProwId { get ; set ; }
        public TrainingResult Prow { get ; set ; }
        
        public System.Guid SternId { get ; set ; }
        public ExternalResearcher Stern { get ; set ; }
    }
}
