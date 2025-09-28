namespace MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities
{
    public class WorkingGroup : Framework.Decisor.Core.Persistence.Entities.Contract.IFullFeatureEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        public bool Archived { get ; set ; }
        
        public bool Enabled { get ; set ; }
        
        public int Priority { get ; set ; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ChiefId))]
        public Framework.Decisor.Domain.Persistence.Entities.Employee Chief { get ; set ; }
        public System.Guid ChiefId { get; set ; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(QualitySpecialistId))]
        public Framework.Decisor.Domain.Persistence.Entities.Employee QualitySpecialist { get; set ; }
        public System.Guid QualitySpecialistId { get; set ; }

        public System.Collections.Generic.List<WorkingGroupTechniqueBridge> TechniqueBridges { get ; set ;} = new System.Collections.Generic.List<WorkingGroupTechniqueBridge>();

        public System.Collections.Generic.List<WorkingGroupEmployeeBridge> EmployeeBridges { get ; set ; } = new System.Collections.Generic.List<WorkingGroupEmployeeBridge>();

    }
}
