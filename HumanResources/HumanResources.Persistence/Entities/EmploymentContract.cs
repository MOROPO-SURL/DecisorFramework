namespace MOROPO.Framework.Decisor.HumanResources.Persistence.Entities
{
    public class EmploymentContract : Legal.Persistence.Entities.Contract.AbstractContract
	{
		[System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(EmployeeId))]
		public Employee Employee { get; set; }
		public System.Guid EmployeeId { get; set; }
	}
}

