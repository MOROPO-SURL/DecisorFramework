namespace MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Display
{
    public class NaturalProviderBudgetProductDisplayModel : Contract.AbstractProviderBudgetProductDisplayModel<Persistence.Entities.NaturalProviderBudgetProduct>
    {
        public NaturalProviderBudgetDisplayModel Budget { get; set; }

        public override void Import(Persistence.Entities.NaturalProviderBudgetProduct entity)
        {
            base.Import(entity);

            if (entity.Budget != null)
            {
                Budget = new NaturalProviderBudgetDisplayModel();

                Budget.Import(entity.Budget);
            }
        }
    }
}
