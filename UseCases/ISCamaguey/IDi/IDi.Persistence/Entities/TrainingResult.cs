namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class TrainingResult : Contract.AbstractResult
    {
        public System.Collections.Generic.List<TrainingResultInternalResearcherBridge> InternalResearcherBridges { get; set; } = new System.Collections.Generic.List<TrainingResultInternalResearcherBridge>();

        public System.Collections.Generic.List<TrainingResultExternalResearcherBridge> ExternalResearcherBridges { get; set; } = new System.Collections.Generic.List<TrainingResultExternalResearcherBridge>();
    }
}
