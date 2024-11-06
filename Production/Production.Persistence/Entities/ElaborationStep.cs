using System.Collections.Generic;

namespace MOROPO.Framework.Decisor.Production.Persistence.Entities
{
    public class ElaborationStep : Guama.Core.Persistence.Entities.Contract.INamedEntity<System.Guid>, Guama.Core.Persistence.Entities.Contract.IPriorizableEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public int Priority { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ElaborationId))]
        public Elaboration Elaboration { get; set; }
        public System.Guid ElaborationId { get; set; }

        public string Description { get; set; }

        public decimal MinDecrease { get; set; }

        public decimal MaxDecrease { get; set; }

        public List<ElaborationStepProductionRoleBridge> ProductionRoleBridges { get; set; } = new List<ElaborationStepProductionRoleBridge>();
    }
}
