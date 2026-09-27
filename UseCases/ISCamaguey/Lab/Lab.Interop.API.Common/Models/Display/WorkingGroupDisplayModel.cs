using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Display
{
    public class WorkingGroupDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.WorkingGroup, System.Guid>
    {
        public System.Guid Id { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Framework.Decisor.Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel Chief { get; set; }

        public Framework.Decisor.Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel QualitySpecialist { get; set; }

        public Domain.Interop.API.Common.Models.Display.TechniqueDisplayModel[] Techniques { get; set; }

        public Framework.Decisor.Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel[] Employees { get; set; }

        public virtual void Import(Persistence.Entities.WorkingGroup entity)
        {
            Id = entity.Id;
            Enabled = entity.Enabled;
            Priority = entity.Priority;
            Name = entity.Name;
            Description = entity.Description;
            Techniques = entity.TechniqueBridges.OrderBy(bridge => bridge.Stern.Priority).Select(bridge =>
            {
                var model = new Domain.Interop.API.Common.Models.Display.TechniqueDisplayModel();

                model.Import(bridge.Stern);

                return model;
            }).ToArray();

            if (entity.Chief != null)
            {
                Chief = new Framework.Decisor.Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel();

                Chief.Import(entity.Chief);
            }

            if (entity.QualitySpecialist != null)
            {
                QualitySpecialist = new Framework.Decisor.Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel();

                QualitySpecialist.Import(entity.QualitySpecialist);
            }
        }
    }
}
