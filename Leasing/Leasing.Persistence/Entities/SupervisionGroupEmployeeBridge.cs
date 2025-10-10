namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities
{
    public class SupervisionGroupEmployeeBridge : Guama.Core.Persistence.Entities.Contract.IBridge<SupervisionGroup, System.Guid, Domain.Persistence.Entities.Employee, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public SupervisionGroup Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Domain.Persistence.Entities.Employee Stern { get; set; }
    }
}
