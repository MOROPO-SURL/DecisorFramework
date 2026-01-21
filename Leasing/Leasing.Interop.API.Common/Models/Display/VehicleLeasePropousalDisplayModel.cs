namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display
{
    public class VehicleLeasePropousalDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.VehicleLeasePropousal, System.Guid>
    {
        public System.Guid Id { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        public System.DateTime At { get; set; } = System.DateTime.Now;

        public string Description { get; set; }

        public Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel Author { get; set; }

        public Governance.Interop.API.Common.Models.Display.AgreementDisplayModel Agreement { get; set; }

        public Domain.Interop.API.Common.Models.Display.VehicleDisplayModel Vehicle { get; set; }

        public decimal BaselineAmount { get; set; }

        public Financial.Interop.API.Common.Models.Display.CurrencyDisplayModel BaselineCurrency { get; set; }

        public void Import(Persistence.Entities.VehicleLeasePropousal entity)
        {
            Id = entity.Id;
            Enabled = entity.Enabled;
            Priority = entity.Priority;
            At = entity.At;
            Description = entity.Description;
            BaselineAmount = entity.BaselineAmount;

            if (entity.Author != null)
            {
                Author = new Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel();

                Author.Import(entity.Author);
            }

            if (entity.Agreement != null)
            {
                Agreement = new Governance.Interop.API.Common.Models.Display.AgreementDisplayModel();

                Agreement.Import(entity.Agreement);
            }

            if (entity.Vehicle != null)
            {
                Vehicle = new Domain.Interop.API.Common.Models.Display.VehicleDisplayModel();

                Vehicle.Import(entity.Vehicle);
            }

            if (entity.BaselineCurrency != null)
            {
                BaselineCurrency = new Financial.Interop.API.Common.Models.Display.CurrencyDisplayModel();

                BaselineCurrency.Import(entity.BaselineCurrency);
            }
        }
    }
}
