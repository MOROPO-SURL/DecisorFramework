namespace MOROPO.Framework.Decisor.HumanResources.Persistence.Entities.Contract
{
    public abstract class AbstractEmploymentContract : Legal.Persistence.Entities.Contract.AbstractContract
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(StaffId))]
        public Staff Staff { get; set; }
        public System.Guid StaffId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(VacantId))]
        public Vacant Vacant { get; set; }
        public System.Guid VacantId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(EmployeeId))]
        public Domain.Persistence.Entities.Employee Employee { get; set; }
        public System.Guid EmployeeId { get; set; }

        public Ocupation RefereceOcupation { get; set; }
    }
}