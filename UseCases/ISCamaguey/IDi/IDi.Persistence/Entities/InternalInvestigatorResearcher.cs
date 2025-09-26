using MOROPO.Framework.Decisor.Domain.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class InternalInvestigatorResearcher : Contract.AbstractBaseResearcher
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; }
        public System.Guid EmployeeId { get; set; }
    }
}
