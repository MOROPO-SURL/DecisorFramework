using MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Input
{
    public class ProjectBudgetFunancingInputModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<ProjectBudgetFunancing, System.Guid>
    {
        public System.Guid Id { get; set; }

        public System.Guid FinancierId { get; set; }

        public System.Guid CurrencyId { get; set; }

        public float Amount { get; set; }

        public ProjectBudgetFunancing Export()
        {
            var entity = new ProjectBudgetFunancing { Id = Id };

            Mergue(entity);

            return entity;
        }

        public void Import(ProjectBudgetFunancing entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(ProjectBudgetFunancing entity)
        {
            entity.Amount = Amount;

            if (entity.FinancierId != FinancierId)
            {
                entity.Financier = null;
                entity.FinancierId = FinancierId;
            }

            if (entity.CurrencyId != CurrencyId)
            {
                entity.Currency = null;
                entity.CurrencyId = CurrencyId;
            }
        }
    }
}
