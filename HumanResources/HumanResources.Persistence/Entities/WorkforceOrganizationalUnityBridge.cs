namespace MOROPO.Framework.Decisor.HumanResources.Persistence.Entities
{
    public class WorkforceOrganizationalUnityBridge : Guama.Core.Persistence.Entities.Contract.IBridge<Workforce, System.Guid, Domain.Persistence.Entities.OrganizationalUnity, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public Workforce Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Domain.Persistence.Entities.OrganizationalUnity Stern { get; set; }
    }
}
