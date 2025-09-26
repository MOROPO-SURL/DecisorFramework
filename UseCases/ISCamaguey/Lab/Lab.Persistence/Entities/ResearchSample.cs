using MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities;
using MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities.Contract;
using MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities
{
    public class ResearchSample: Contract.AbstractBaseSample
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ProjectId))]
        public Project Project { get; set; }
        public System.Guid ProjectId { get; set; }


        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(AbstracBaseResearcherId))]
        public AbstractBaseResearcher AbstracBaseResearcher { get; set; }
        public System.Guid AbstracBaseResearcherId { get; set; }
    }
}
