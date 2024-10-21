namespace MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Display
{
    public class PurchasePlanDepartureDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.PurchasePlanDeparture, System.Guid>
    {
        public System.Guid Id { get; set; }

        public void Import(Persistence.Entities.PurchasePlanDeparture entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
