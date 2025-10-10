namespace MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Display
{
    public class PurchaseCashAdvanceDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.PurchaseCashAdvance, System.Guid>
    {
        public System.Guid Id { get; set; }

        public System.DateTime At { get; set; }

        public decimal Amount { get; set; }

        public PurchasePlanDisplayModel PurchasePlan { get; set; }

        public Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel Responsible { get; set; }

        public void Import(Persistence.Entities.PurchaseCashAdvance entity)
        {
            Id = entity.Id;
            At = entity.At;
            Amount = entity.Amount;

            if (entity.PurchasePlan != null)
            {
                PurchasePlan = new PurchasePlanDisplayModel();

                PurchasePlan.Import(entity.PurchasePlan);
            }

            if (entity.Responsible != null)
            {
                Responsible = new Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel();

                Responsible.Import(entity.Responsible);
            }
        }
    }
}
