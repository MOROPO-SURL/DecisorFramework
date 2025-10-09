namespace MOROPO.Framework.Decisor.HumanResources.Persistence.Entities
{
    public class EmployeeDailyChecking : Guama.Core.Persistence.Entities.Contract.IEntity<long>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public long Id { get; set; }

        public System.DateTime At { get; set; } = System.DateTime.Now;

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(EmployeeId))]
        public Domain.Persistence.Entities.Employee Employee { get; set; }
        public System.Guid EmployeeId { get; set; }

        public int Day { get; set; }

        [System.ComponentModel.DataAnnotations.Range(1,12)]
        public int Month { get; set; }

        public int Year { get; set; }

        public System.TimeSpan CheckIn { get; set; }

        public System.TimeSpan? PartialCheckOut { get; set; }

        public System.TimeSpan? PartialCheckIn { get; set; }

        public System.TimeSpan? CheckOut { get; set; }

        public System.TimeSpan? ExtraCheckIn { get; set; }

        public System.TimeSpan? ExtraCheckOut { get; set; }
    }
}
