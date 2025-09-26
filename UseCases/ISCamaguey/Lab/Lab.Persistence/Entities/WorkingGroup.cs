using MOROPO.Framework.Decisor.Domain.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities
{
    public class WorkingGroup : Framework.Decisor.Core.Persistence.Entities.Contract.IFullFeatureEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public bool Archived { get ; set ; }
        
        public bool Enabled { get ; set ; }
        
        public int Priority { get ; set ; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ChiefEmployeeId))]
        public Employee ChiefEmployee { get ; set ; }
        public System.Guid ChiefEmployeeId { get; set ; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(QualitySpecialistEmployeeId))]
        public Employee QualitySpecialistEmployee { get; set ; }
        public System.Guid QualitySpecialistEmployeeId { get; set ; }

        public System.Collections.Generic.List<WorkingGroupTechniqueBridge> TechniqueBridges { get ; set ;} = new System.Collections.Generic.List<WorkingGroupTechniqueBridge>();

        public System.Collections.Generic.List<WorkingGroupEmployeeBridge> EmployeeBridges { get ; set ; } = new System.Collections.Generic.List<WorkingGroupEmployeeBridge>();

    }
}
