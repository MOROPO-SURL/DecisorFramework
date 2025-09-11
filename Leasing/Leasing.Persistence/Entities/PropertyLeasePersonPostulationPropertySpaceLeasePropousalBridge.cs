namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities
{
    public class PropertyLeasePersonPostulationPropertySpaceLeasePropousalBridge : Guama.Core.Persistence.Entities.Contract.IBridge<PropertyLeasePersonPostulation, System.Guid, PropertySpaceLeasePropousal, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public PropertyLeasePersonPostulation Prow { get; set; }

        public System.Guid SternId { get; set; }
        public PropertySpaceLeasePropousal Stern { get; set; }
    }
}