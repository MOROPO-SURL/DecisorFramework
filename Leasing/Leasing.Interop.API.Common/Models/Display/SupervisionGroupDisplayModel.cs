namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display
{
    public class SupervisionGroupDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.SupervisionGroup, System.Guid>
    {
        public System.Guid Id { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        public System.DateTime At { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel Representative { get; set; }

        public Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel[] Members { get; set; }

        public void Import(Persistence.Entities.SupervisionGroup entity)
        {
            Id = entity.Id;
            Enabled = entity.Enabled;
            Priority = entity.Priority;
            At = entity.At;
            Name = entity.Name;
            Description = entity.Description;

            if (entity.Representative != null)
            {
                Representative = new Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel();

                Representative.Import(entity.Representative);
            }
        }
    }
}
