namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display
{
    public class EmployeeDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.Employee, System.Guid>
    {
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public int Priority { get; set; }

        public System.DateTime At { get; set; }

        public Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel Contact { get; set; }

        public virtual void Import(Persistence.Entities.Employee entity)
        {
            Id = entity.Id;
            Priority = entity.Priority;
            At = entity.At;

            if (entity.Contact != null)
            {
                Contact = new Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel();

                Contact.Import(entity.Contact);
            }
        }

        public override string ToString()
        {
            return Contact.ToString();
        }
    }
}
