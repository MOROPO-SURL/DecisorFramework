using System;
using System.Collections.Generic;
using System.Text;

namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class ProjectParticipatingEntityBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<Project, Guid, ParticipatingEntity, Guid>
    {
        public Guid ProwId { get ; set ; }
        public Project Prow { get ; set ; }
        
        public Guid SternId { get ; set ; }
        public ParticipatingEntity Stern { get ; set ; }
    }
}
