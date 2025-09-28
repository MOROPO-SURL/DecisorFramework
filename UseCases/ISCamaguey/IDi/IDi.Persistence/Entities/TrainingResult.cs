namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class TrainingResult : Contract.AbstractResult
    {
        public System.Collections.Generic.List<TrainingResultResearcherBridge> ResearcherBridges { get; set; } = new System.Collections.Generic.List<TrainingResultResearcherBridge>();
    }
}
