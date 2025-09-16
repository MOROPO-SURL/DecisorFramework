namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities
{
    public class NaturalClientPropertyLeasingPersonContactBridge : Guama.Core.Persistence.Entities.Contract.IBridge<NaturalClientPropertyLeasing, System.Guid, Domain.Persistence.Entities.PersonContact, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public NaturalClientPropertyLeasing Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Domain.Persistence.Entities.PersonContact Stern { get; set; }
    }
}
