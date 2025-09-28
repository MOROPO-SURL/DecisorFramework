namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class PublicationResult : Contract.AbstractResult
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(MainAuthorId))]
        public Contract.AbstractResearcher MainAuthor { get; set; }
        public System.Guid MainAuthorId { get; set; }

        public System.Collections.Generic.List<PublicationResultResearcherBridge> ResearcherBridges { get; set; } = new System.Collections.Generic.List<PublicationResultResearcherBridge>();

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(Title))]
        public string Title { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(DocumentId))]
        public Framework.Guama.Media.Persistence.Entities.Document Document { get; set; }
        public System.Guid DocumentId { get; set; }
    }
}
