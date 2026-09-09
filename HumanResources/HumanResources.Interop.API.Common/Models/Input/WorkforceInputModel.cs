using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display;
using System.Collections.Generic;

namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Input
{
    public class WorkforceInputModel : Core.Interop.API.Common.Models.Input.Contract.AbstractNotificableEntityInputModel<Persistence.Entities.Workforce, System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public int Priority { get; set; }

        public System.DateTime At { get; set; }

        public System.Guid OrganizationalStructureId { get; set; }

        public List<WorkforceOrganizationalUnitInputModel> EditionOrganizationalUnits { get; set; } = new List<WorkforceOrganizationalUnitInputModel>();

        public List<WorkforceOrganizationalUnitInputModel> IncomingOrganizationalUnits { get; set; } = new List<WorkforceOrganizationalUnitInputModel>();

        public List<WorkforceOrganizationalUnitDisplayModel> OutgoingOrganizationalUnits { get; set; } = new List<WorkforceOrganizationalUnitDisplayModel>();

        public override Persistence.Entities.Workforce Export()
        {
            var entity = new Persistence.Entities.Workforce { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Persistence.Entities.Workforce entity)
        {
            entity.At = System.DateTime.Now;
            entity.Name = Name;
            entity.Priority = Priority;

            if (entity.OrganizationalStructureId != OrganizationalStructureId)
            {
                entity.OrganizationalStructure = null;
                entity.OrganizationalStructureId = OrganizationalStructureId;
            }
        }
    }
}
