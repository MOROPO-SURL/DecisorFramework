using MOROPO.ISCamaguey.Decisor.Domain.Persistence.Entities;
using MOROPO.ISCamaguey.Decisor.Domain.Persistence.Entities.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class NewTechniqueResult : Contract.AbstractResult
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(TechniqueId))]
        public Technique Technique { get; set; }
        public System.Guid TechniqueId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(TechniquePredecessorId))]
        public Technique TechniquePredecessor  { get; set; }
        public System.Guid TechniquePredecessorId { get; set; }
    }
}
