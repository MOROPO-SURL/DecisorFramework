using MOROPO.Framework.Decisor.Commercial.Persistence.Entities;
using MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities
{
    public class LegalClientTrainingServiceOrder : AbstractBasicTrainingServiceOrder
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(LegalClientId))]
        public LegalClient LegalClient { get; set; }
        public System.Guid LegalClientId { get; set; }
    }
}
