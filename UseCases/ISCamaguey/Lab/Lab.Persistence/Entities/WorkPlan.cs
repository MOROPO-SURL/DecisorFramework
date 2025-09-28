namespace MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities
{
    public class WorkPlan : Framework.Decisor.Core.Persistence.Entities.Contract.IFullFeatureEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        public bool Archived { get ; set ; }
        
        public bool Enabled { get ; set ; }
        
        public int Priority { get ; set ; }

        public System.DateTime At { get; set; }

        public string Description { get; set; }
    }
}
