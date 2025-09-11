namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities
{
    public class PropertyLeaseOrganizationPostulationPropertySpaceLeasePropousalBridge : Guama.Core.Persistence.Entities.Contract.IBridge<PropertyLeaseOrganizationPostulation, System.Guid, PropertySpaceLeasePropousal, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public PropertyLeaseOrganizationPostulation Prow { get; set; }

        public System.Guid SternId { get; set; }
        public PropertySpaceLeasePropousal Stern { get; set; }
    }
}
