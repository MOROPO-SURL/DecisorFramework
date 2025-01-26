namespace MOROPO.Framework.Decisor.HumanResources.Persistence.Entities
{
    public class StaffWorkforceBridge : Guama.Core.Persistence.Entities.Contract.IBridge<Staff, System.Guid, Workforce, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public Staff Prow { get; set; }

        public System.Guid SternId { get; set; }
        public Workforce Stern { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Title { get; set; }

        public string Description { get; set; }
    }
}