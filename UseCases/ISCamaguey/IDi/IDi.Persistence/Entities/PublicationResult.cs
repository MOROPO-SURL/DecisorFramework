using MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class PublicationResult : Contract.AbstractResult
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(AbstractBaseResearcherId))]
        public AbstractResearcher AbstractBaseResearcher { get; set; }
        public System.Guid AbstractBaseResearcherId { get; set; }

        public System.Collections.Generic.List<PublicationResultAbstractBaseResearcherBridge> AbstractBaseResearcherBridges { get; set; } = new System.Collections.Generic.List<PublicationResultAbstractBaseResearcherBridge>();
    }
}
