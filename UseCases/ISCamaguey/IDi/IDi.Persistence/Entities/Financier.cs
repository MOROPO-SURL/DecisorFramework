namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class Financier : Framework.Decisor.Core.Persistence.Entities.Contract.IFullFeatureEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        public bool Archived { get ; set ; }
        
        public bool Enabled { get ; set ; }
        
        public int Priority { get ; set ; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ContactId))]
        public Framework.Decisor.Domain.Persistence.Entities.OrganizationContact Contact { get; set; }
        public System.Guid ContactId { get; set; }
        
        public System.Collections.Generic.List<FinancierResearchAreaBridge> ResearchAreaBridges { get; set; } = new System.Collections.Generic.List<FinancierResearchAreaBridge>();

        public System.Collections.Generic.List<FinancierDocumentBridge> DocumentBridges { get; set; } = new System.Collections.Generic.List<FinancierDocumentBridge>();
    }
}
