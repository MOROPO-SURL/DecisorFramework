namespace MOROPO.Framework.Decisor.HumanResources.Persistence.Entities
{
    public class Ocupation : Guama.Core.Persistence.Entities.Contract.IEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(StaffId))]
        public Staff Staff { get; set; }
        public System.Guid StaffId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(WorkforceId))]
        public Workforce Workforce { get; set; }
        public System.Guid WorkforceId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(VacantId))]
        public Vacant Vacant { get; set; }
        public System.Guid VacantId { get; set; }

        public System.DateTime At { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; }
        public System.Guid EmployeeId { get; set; }
    }
}
