namespace MOROPO.Framework.Decisor.Governance.Persistence.Entities
{
    public class DecisionMakingGroupContactBridge : Guama.Core.Persistence.Entities.Contract.IBridge<DecisionMakingGroup, System.Guid, Domain.Persistence.Entities.PersonContact, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public DecisionMakingGroup Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Domain.Persistence.Entities.PersonContact Stern { get; set; }
    }
}
