namespace MOROPO.Framework.Decisor.Essential.Persistence.Entities
{
    public class EmploymentContract : Contract.AbstractContract
	{
		[System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(EmployeeId))]
		public Employee Employee { get; set; }
		public System.Guid EmployeeId { get; set; }
	}
}

