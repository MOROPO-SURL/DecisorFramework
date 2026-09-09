using System.Collections.Generic;

namespace MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Input
{
    public class OrganizationalStructureInputModel : Core.Interop.API.Common.Models.Input.Contract.AbstractNotificableEntityInputModel<Persistence.Entities.OrganizationalStructure, System.Guid>
    {
        public int Priority { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MaxLength(255)]
        public string Name { get; set; }

        public OrganizationalStructuringUnitInputModel RootStructuringUnit { get; set; }

        public List<OrganizationalStructuringUnitInputModel> EditionStructuringUnits { get; set; } = new List<OrganizationalStructuringUnitInputModel>();
        public List<OrganizationalStructuringUnitInputModel> IncomingStructuringUnits { get; set; } = new List<OrganizationalStructuringUnitInputModel>();
        public List<Display.OrganizationalStructuringUnitDisplayModel> OutgoingStructuringUnits { get; set; } = new List<Display.OrganizationalStructuringUnitDisplayModel>();

        public override Persistence.Entities.OrganizationalStructure Export()
        {
            var entity = new Persistence.Entities.OrganizationalStructure { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Persistence.Entities.OrganizationalStructure entity)
        {
            entity.Name = Name;
            entity.Priority = Priority;
        }
    }
}
