namespace MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Input
{
    public class NaturalProviderBudgetProductInputModel : Contract.AbstractProviderBudgetProductInputModel<Persistence.Entities.NaturalProviderBudgetProduct>
    {
        public override Persistence.Entities.NaturalProviderBudgetProduct Export()
        {
            var entity = new Persistence.Entities.NaturalProviderBudgetProduct { Id = System.Guid.NewGuid() };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Persistence.Entities.NaturalProviderBudgetProduct entity)
        {
            base.Mergue(entity);

            if (entity.BudgetId != BudgetId)
            {
                entity.Budget = null;
                entity.BudgetId = BudgetId;
            }
        }
    }
}
