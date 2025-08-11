namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display
{
    public class PropertyLeasePropousalDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.PropertyLeasePropousal, System.Guid>
    {
        public System.Guid Id { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        public System.DateTime At { get; set; } = System.DateTime.Now;

        public string Description { get; set; }

        public HumanResources.Interop.API.Common.Models.Display.EmployeeDisplayModel Author { get; set; }

        public Governance.Interop.API.Common.Models.Display.AgreementDisplayModel Agreement { get; set; }

        public Domain.Interop.API.Common.Models.Display.PropertyDisplayModel Property { get; set; }

        public PropertySpaceLeasePropousalDisplayModel[] SpacePropousals { get; set; }

        public void Import(Persistence.Entities.PropertyLeasePropousal entity)
        {
            Id = entity.Id;
            Enabled = entity.Enabled;
            Priority = entity.Priority;
            At = entity.At;
            Description = entity.Description;

            if (entity.Author != null)
            {
                Author = new HumanResources.Interop.API.Common.Models.Display.EmployeeDisplayModel();

                Author.Import(entity.Author);
            }

            if (entity.Agreement != null)
            {
                Agreement = new Governance.Interop.API.Common.Models.Display.AgreementDisplayModel();

                Agreement.Import(entity.Agreement);
            }

            if (entity.Property != null)
            {
                Property = new Domain.Interop.API.Common.Models.Display.PropertyDisplayModel();

                Property.Import(entity.Property);
            }
        }
    }
}
