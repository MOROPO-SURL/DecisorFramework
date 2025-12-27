namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class CallForProposal : Framework.Guama.Core.Persistence.Entities.Contract.IArchivableEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        public bool Archived { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public System.DateTime At { get; set; } = System.DateTime.Now;

        public System.DateTime StartAt { get; set; }

        public System.DateTime EndAt { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(FinancierId))]
        public Financier Financier { get; set; }
        public System.Guid FinancierId { get; set; }

        public System.Collections.Generic.List<CallForProposalResearchAreaBridge> ResearchAreaBridges { get; set; } = new System.Collections.Generic.List<CallForProposalResearchAreaBridge>();

        public System.Collections.Generic.List<CallForProposalDocumentBridge> DocumentBridges { get; set; } = new System.Collections.Generic.List<CallForProposalDocumentBridge>();
    }
}
