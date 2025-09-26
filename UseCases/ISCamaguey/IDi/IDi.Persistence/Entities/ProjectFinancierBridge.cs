using System;
using System.Collections.Generic;
using System.Text;

namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class ProjectFinancierBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<Project, Guid, Financier, Guid>
    {
        public Guid ProwId { get ; set ; }
        public Project Prow { get ; set ; }
        
        public Guid SternId { get ; set ; }
        public Financier Stern { get ; set ; }
    }
}
