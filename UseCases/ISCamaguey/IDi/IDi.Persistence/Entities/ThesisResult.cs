namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class ThesisResult : Contract.AbstractResult
    {
        [System.ComponentModel.DataAnnotations.Required]
        public string Title { get; set; }

        public Enumerations.ThesisKind ThesisKind { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(DocumentId))]
        public Framework.Guama.Media.Persistence.Entities.Document Document { get; set; }
        public System.Guid DocumentId { get; set; }

        public System.Collections.Generic.List<ThesisResultInternalResearcherBridge> InternalResearcherBridges { get; set; } = new System.Collections.Generic.List<ThesisResultInternalResearcherBridge>();

        public System.Collections.Generic.List<ThesisResultExternalResearcherBridge> ExternalResearcherBridges { get; set; } = new System.Collections.Generic.List<ThesisResultExternalResearcherBridge>();
    }
}
