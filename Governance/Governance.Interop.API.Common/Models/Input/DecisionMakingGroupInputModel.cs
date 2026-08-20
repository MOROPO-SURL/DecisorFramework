using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using System.Collections.Generic;
using System.Linq;

namespace MOROPO.Framework.Decisor.Governance.Interop.API.Common.Models.Input
{
    public class DecisionMakingGroupInputModel : Core.Interop.API.Common.Models.Input.Contract.AbstractNotificableEntityInputModel<Persistence.Entities.DecisionMakingGroup, System.Guid>
    {
        public System.Guid StructureId { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public System.Guid LeaderId { get; set; }

        public string Description { get; set; }

        public int Priority { get; set; }

        public List<EmployeeDisplayModel> Members { get; set; } = new List<EmployeeDisplayModel>();

        public List<PersonContactDisplayModel> Collaborators { get; set; } = new List<PersonContactDisplayModel>();

        public override Persistence.Entities.DecisionMakingGroup Export()
        {
            var entity = new Persistence.Entities.DecisionMakingGroup { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Persistence.Entities.DecisionMakingGroup entity)
        {
            entity.Name = Name;
            entity.Description = Description;
            entity.Priority = Priority;

            if (entity.AdministrativeEntityId != StructureId)
            {
                entity.AdministrativeEntity = null;
                entity.AdministrativeEntityId = StructureId;
            }

            if (entity.LeaderId != LeaderId)
            {
                entity.Leader = null;
                entity.LeaderId = LeaderId;
            }

            entity.EmployeeBridges.Clear();

            entity.EmployeeBridges = Members.Select(model => new Persistence.Entities.DecisionMakingGroupEmployeeBridge
            {
                ProwId = entity.Id,
                SternId = model.Id
            }).ToList();

            entity.ContactBridges.Clear();

            entity.ContactBridges = Collaborators.Select(model => new Persistence.Entities.DecisionMakingGroupContactBridge
            {
                ProwId = entity.Id,
                SternId = model.Id
            }).ToList();
        }
    }
}
