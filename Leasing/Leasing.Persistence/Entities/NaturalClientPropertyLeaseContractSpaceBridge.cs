namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities
{
    public class NaturalClientPropertyLeaseContractSpaceBridge : Guama.Core.Persistence.Entities.Contract.IBridge<NaturalClientPropertyLeaseContract, int, Domain.Persistence.Entities.PropertySpace, System.Guid>
    {
        public int ProwId { get; set; }
        public NaturalClientPropertyLeaseContract Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Domain.Persistence.Entities.PropertySpace Stern { get; set; }
    }
}
