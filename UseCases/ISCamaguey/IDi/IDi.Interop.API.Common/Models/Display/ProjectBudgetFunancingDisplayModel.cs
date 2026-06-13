namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display
{
    public class ProjectBudgetFunancingDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.ProjectBudgetFunancing, System.Guid>
    {
        public System.Guid Id { get; set; }

        public FinancierDisplayModel Financier { get; set; }

        public Framework.Decisor.Financial.Interop.API.Common.Models.Display.CurrencyDisplayModel Currency { get; set; }

        public float Amount { get; set; }

        public void Import(Persistence.Entities.ProjectBudgetFunancing entity)
        {
            Id = entity.Id;
            Amount = entity.Amount;

            if (entity.Financier != null)
            {
                Financier = new FinancierDisplayModel();

                Financier.Import(entity.Financier);
            }

            if (entity.Currency != null)
            {
                Currency = new Framework.Decisor.Financial.Interop.API.Common.Models.Display.CurrencyDisplayModel();

                Currency.Import(entity.Currency);
            }
        }
    }
}
