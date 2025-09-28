namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class ProjectBudgetCurrencyBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<Project, System.Guid, Framework.Decisor.Financial.Persistence.Entities.Currency, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public Project Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Framework.Decisor.Financial.Persistence.Entities.Currency Stern { get; set; }

        public float Amount { get; set; }
    }
}
