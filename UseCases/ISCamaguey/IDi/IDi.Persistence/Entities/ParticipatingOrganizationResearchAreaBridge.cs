namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class ParticipatingOrganizationResearchAreaBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<ParticipatingOrganization, System.Guid, ResearchArea, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public ParticipatingOrganization Prow { get; set; }

        public System.Guid SternId { get; set; }
        public ResearchArea Stern { get; set; }
    }
}
