namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class ScientificTechnicalResultIntroduction : Framework.Decisor.Core.Persistence.Entities.Contract.IFullFeatureEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        public string Description { get; set; }

        public bool Archived { get ; set ; }
        
        public bool Enabled { get ; set ; }
        
        public int Priority { get ; set ; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Scenery { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ResultId))]
        public ScientificTechnicalResult Result { get ; set ; }
        public System.Guid ResultId { get ; set ; }
    }
}
