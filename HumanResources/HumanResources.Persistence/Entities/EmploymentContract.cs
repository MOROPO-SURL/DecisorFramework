namespace MOROPO.Framework.Decisor.HumanResources.Persistence.Entities
{
    public class EmploymentContract : Legal.Persistence.Entities.Contract.AbstractContract
	{
		[System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(OcupationId))]
		public Ocupation Ocupation { get; set; }
		public System.Guid OcupationId { get; set; }
	}
}