namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class PublicationResult : Contract.AbstractResult
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(Title))]
        public string Title { get; set; }

        public System.Collections.Generic.List<PublicationResultInternalResearcherBridge> InternalResearcherBridges { get; set; } = new System.Collections.Generic.List<PublicationResultInternalResearcherBridge>();

        public System.Collections.Generic.List<PublicationResultExternalResearcherBridge> ExternalResearcherBridges { get; set; } = new System.Collections.Generic.List<PublicationResultExternalResearcherBridge>();

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(DocumentId))]
        public Framework.Guama.Media.Persistence.Entities.Document Document { get; set; }
        public System.Guid DocumentId { get; set; }
    }
}
