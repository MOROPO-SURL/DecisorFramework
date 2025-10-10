namespace MOROPO.Framework.Decisor.Governance.Persistence.Entities
{
    public class DecisionMakingGroupEmployeeBridge : Guama.Core.Persistence.Entities.Contract.IBridge<DecisionMakingGroup, System.Guid, Domain.Persistence.Entities.Employee, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public DecisionMakingGroup Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Domain.Persistence.Entities.Employee Stern { get; set; }
    }
}
