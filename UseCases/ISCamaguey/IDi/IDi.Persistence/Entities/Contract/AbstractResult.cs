namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities.Contract
{
    public abstract class AbstractResult : Framework.Decisor.Core.Persistence.Entities.Contract.IFullFeatureEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public bool Archived { get ; set ; }
        
        public bool Enabled { get ; set ; }
        
        public int Priority { get ; set ; }

        public System.DateTime At {  get; set; }
        
    }
}
