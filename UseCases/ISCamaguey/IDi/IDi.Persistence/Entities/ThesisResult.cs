namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class ThesisResult : Contract.AbstractResult
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(Title))]
        public string Title { get; set; }

        public System.Collections.Generic.List<ThesisResultInternalResearcherBridge> InternalResearcherBridges { get; set; } = new System.Collections.Generic.List<ThesisResultInternalResearcherBridge>();

        public System.Collections.Generic.List<ThesisResultExternalResearcherBridge> ExternalResearcherBridges { get; set; } = new System.Collections.Generic.List<ThesisResultExternalResearcherBridge>();
    }
}
