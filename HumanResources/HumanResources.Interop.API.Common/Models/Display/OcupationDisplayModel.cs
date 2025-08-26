namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display
{
    public class OcupationDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.Ocupation, System.Guid>
    {
        public System.Guid Id { get; set; }

        public System.Guid VacantId { get; set; }

        public System.DateTime At { get; set; }

        public Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel Employee { get; set; }

        public void Import(Persistence.Entities.Ocupation entity)
        {
            Id = entity.Id;
            VacantId = entity.Contract.VacantId;
            At = entity.At;

            if (entity.Contract.Employee != null)
            {
                Employee = new Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel();

                Employee.Import(entity.Contract.Employee);
            }
        }
    }
}
