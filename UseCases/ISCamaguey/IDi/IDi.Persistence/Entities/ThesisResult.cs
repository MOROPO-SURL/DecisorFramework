namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class ThesisResult : Contract.AbstractResult
    {
        [System.ComponentModel.DataAnnotations.Required]
        public string Title { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ProjectId))]
        public Project Project { get; set; }
        public System.Guid? ProjectId { get; set; }

        public System.Collections.Generic.List<ThesisResultInternalResearcherBridge> InternalResearcherBridges { get; set; } = new System.Collections.Generic.List<ThesisResultInternalResearcherBridge>();

        public System.Collections.Generic.List<ThesisResultExternalResearcherBridge> ExternalResearcherBridges { get; set; } = new System.Collections.Generic.List<ThesisResultExternalResearcherBridge>();
    }
}
