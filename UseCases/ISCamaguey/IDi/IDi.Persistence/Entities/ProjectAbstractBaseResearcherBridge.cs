using MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class ProjectAbstractBaseResearcherBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<Project, Guid, AbstractBaseResearcher, Guid>
    {
        public Guid ProwId { get ; set ; }
        public Project Prow { get ; set ; }
        
        public Guid SternId { get ; set ; }
        public AbstractBaseResearcher Stern { get ; set ; }
    }
}
