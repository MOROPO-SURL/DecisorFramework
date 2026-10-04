using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Input
{
    public class WorkingGroupInputModel : Framework.Decisor.Core.Interop.API.Common.Models.Input.Contract.AbstractNotificableEntityInputModel<Persistence.Entities.WorkingGroup, System.Guid>
    {
        public int Priority { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public System.Guid ChiefId { get; set; }

        public System.Guid QualitySpecialistId { get; set; }

        public System.Collections.Generic.List<Domain.Interop.API.Common.Models.Display.TechniqueDisplayModel> Techniques { get; set; } = new System.Collections.Generic.List<Domain.Interop.API.Common.Models.Display.TechniqueDisplayModel>();

        public System.Collections.Generic.List<Framework.Decisor.Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel> Employees { get; set; } = new System.Collections.Generic.List<Framework.Decisor.Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel>();

        public override Persistence.Entities.WorkingGroup Export()
        {
            var entity = new Persistence.Entities.WorkingGroup { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Persistence.Entities.WorkingGroup entity)
        {
            entity.Priority = Priority;
            entity.Name = Name;
            entity.Description = Description;

            if (entity.ChiefId != ChiefId)
            {
                entity.Chief = null;
                entity.ChiefId = ChiefId;
            }

            if (entity.QualitySpecialistId != QualitySpecialistId)
            {
                entity.QualitySpecialist = null;
                entity.QualitySpecialistId = QualitySpecialistId;
            }

            entity.TechniqueBridges.Clear();
            entity.TechniqueBridges = Techniques.Select(model => new Persistence.Entities.WorkingGroupTechniqueBridge { ProwId = entity.Id, SternId = model.Id }).ToList();

            entity.EmployeeBridges.Clear();
            entity.EmployeeBridges = Employees.Select(model => new Persistence.Entities.WorkingGroupEmployeeBridge { ProwId = entity.Id, SternId = model.Id }).ToList();
        }
    }
}
