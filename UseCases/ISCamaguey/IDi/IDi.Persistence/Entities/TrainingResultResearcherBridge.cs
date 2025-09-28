namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class TrainingResultResearcherBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<TrainingResult, System.Guid, Contract.AbstractResearcher, System.Guid>
    {
        public System.Guid ProwId { get ; set ; }
        public TrainingResult Prow { get ; set ; }
        
        public System.Guid SternId { get ; set ; }
        public Contract.AbstractResearcher Stern { get ; set ; }
    }
}
