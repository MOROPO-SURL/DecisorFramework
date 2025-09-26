using MOROPO.ISCamaguey.Decisor.Domain.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities
{
    public class WorkingGroupTechniqueBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<WorkingGroup, System.Guid, Technique, System.Guid>
    {
        public Guid ProwId { get ; set ; }
        public WorkingGroup Prow { get ; set ; }
       
        public Guid SternId { get ; set ; }
        public Technique Stern { get ; set ; }
    }
}
