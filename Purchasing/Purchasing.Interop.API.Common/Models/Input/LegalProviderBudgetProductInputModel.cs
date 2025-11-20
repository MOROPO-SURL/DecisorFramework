namespace MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Input
{
    public class LegalProviderBudgetProductInputModel : Contract.AbstractProviderBudgetProductInputModel<Persistence.Entities.LegalProviderBudgetProduct>
    {
        public override Persistence.Entities.LegalProviderBudgetProduct Export()
        {
            var entity = new Persistence.Entities.LegalProviderBudgetProduct { Id = System.Guid.NewGuid() };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Persistence.Entities.LegalProviderBudgetProduct entity)
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
