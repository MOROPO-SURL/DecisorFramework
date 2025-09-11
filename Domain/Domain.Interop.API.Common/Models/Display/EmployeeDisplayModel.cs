namespace MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display
{
    public class EmployeeDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.Employee, System.Guid>
    {
        public System.Guid Id { get; set; }

        public int Priority { get; set; }

        public System.DateTime At { get; set; }

        public PersonContactDisplayModel Contact { get; set; }

        public virtual void Import(Persistence.Entities.Employee entity)
        {
            Id = entity.Id;
            Priority = entity.Priority;
            At = entity.At;

            if (entity.Contact != null)
            {
                Contact = new PersonContactDisplayModel();

                Contact.Import(entity.Contact);
            }
        }

        public override string ToString()
        {
            return Contact.ToString();
        }
    }
}
