using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using System.Collections.Generic;
using System.Linq;

namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input
{
    public class SupervisionGroupInputModel : Core.Interop.API.Common.Models.Input.Contract.AbstractNotificableEntityInputModel<Persistence.Entities.SupervisionGroup, System.Guid>
    {
        public int Priority { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public System.Guid RepresentativeId { get; set; }

        public List<EmployeeDisplayModel> Members { get; set; } = new List<EmployeeDisplayModel>();

        public override Persistence.Entities.SupervisionGroup Export()
        {
            var entity = new Persistence.Entities.SupervisionGroup { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Persistence.Entities.SupervisionGroup entity)
        {
            entity.Priority = Priority;
            entity.Name = Name;
            entity.Description = Description;

            if (entity.RepresentativeId != RepresentativeId)
            {
                entity.Representative = null;
                entity.RepresentativeId = RepresentativeId;
            }

            entity.EmployeeBridges.Clear();

            entity.EmployeeBridges = Members.Select(model => new Persistence.Entities.SupervisionGroupEmployeeBridge
            {
                ProwId = entity.Id,
                SternId = model.Id
            }).ToList();
        }
    }
}
