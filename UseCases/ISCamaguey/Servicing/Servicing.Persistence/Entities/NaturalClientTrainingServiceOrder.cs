using MOROPO.Framework.Decisor.Commercial.Persistence.Entities;
using MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities
{
    public class NaturalClientTrainingServiceOrder : AbstractBasicTrainingServiceOrder
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(NaturalClientId))]
        public NaturalClient NaturalClient { get; set; }
        public System.Guid NaturalClientId { get; set; }
    }
}
