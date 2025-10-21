namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class FinancierResearchAreaBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<Financier, System.Guid, ResearchArea, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public Financier Prow { get; set; }

        public System.Guid SternId { get; set; }
        public ResearchArea Stern { get; set; }
    }
}
