namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class Extension : Framework.Decisor.Core.Persistence.Entities.Contract.IFullFeatureEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        public bool Archived { get ; set ; }
        
        public bool Enabled { get ; set ; }
        
        public int Priority { get ; set ; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ProjectId))]
        public Project Project { get; set; }
        public System.Guid ProjectId { get; set; }

        public System.DateTime At { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Description { get; set; }
    }
}
