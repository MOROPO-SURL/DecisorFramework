namespace MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Display
{
    public class LegalProviderBudgetProductDisplayModel : Contract.AbstractProviderBudgetProductDisplayModel<Persistence.Entities.LegalProviderBudgetProduct>
    {
        public LegalProviderBudgetDisplayModel Budget { get; set; }

        public override void Import(Persistence.Entities.LegalProviderBudgetProduct entity)
        {
            base.Import(entity);

            if (entity.Budget != null)
            {
                Budget = new LegalProviderBudgetDisplayModel();

                Budget.Import(entity.Budget);
            }
        }
    }
}
