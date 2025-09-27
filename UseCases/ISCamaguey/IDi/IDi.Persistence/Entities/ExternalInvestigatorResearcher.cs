using System;
using System.Collections.Generic;
using System.Text;

namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class ExternalInvestigatorResearcher : Contract.AbstractResearcher
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ParticipatingEntityId))]
        public ParticipatingEntity ParticipatingEntity { get; set; }
        public System.Guid ParticipatingEntityId { get; set; }
    }
}
