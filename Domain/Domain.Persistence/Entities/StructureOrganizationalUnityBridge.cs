namespace MOROPO.Framework.Decisor.Domain.Persistence.Entities
{
    public class StructureOrganizationalUnityBridge : Guama.Core.Persistence.Entities.Contract.IBridge<Structure, System.Guid, OrganizationalUnity, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public Structure Prow { get; set; }

        public System.Guid SternId { get; set; }
        public OrganizationalUnity Stern { get; set; }
    }
}
