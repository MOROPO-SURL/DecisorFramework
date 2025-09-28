namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class ResearcherResearchAreaDoctorateBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<Contract.AbstractResearcher, System.Guid, ResearchArea, System.Guid>
    {
        public System.Guid ProwId { get; set; }

        public Contract.AbstractResearcher Prow { get; set; }

        public System.Guid SternId { get; set; }

        public ResearchArea Stern { get; set; }
    }
}
