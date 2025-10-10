namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display
{
    public class EmployeeDailyCheckingDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.EmployeeDailyChecking, long>
    {
        public long Id { get; set; }

        public System.Guid EmployeeId { get; set; }

        public System.DateTime At { get; set; }

        public int Day { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }

        public System.TimeSpan CheckIn { get; set; }

        public System.TimeSpan? PartialCheckOut { get; set; }

        public System.TimeSpan? PartialCheckIn { get; set; }

        public System.TimeSpan? CheckOut { get; set; }

        public System.TimeSpan? ExtraCheckIn { get; set; }

        public System.TimeSpan? ExtraCheckOut { get; set; }

        public void Import(Persistence.Entities.EmployeeDailyChecking entity)
        {
            Id = entity.Id;
            EmployeeId = entity.EmployeeId;
            At = entity.At;
            Day = entity.Day;
            Month = entity.Month;
            Year = entity.Year;
            CheckIn = entity.CheckIn;
            PartialCheckOut = entity.PartialCheckOut;
            PartialCheckIn = entity.PartialCheckIn;
            CheckOut = entity.CheckOut;
            ExtraCheckIn = entity.ExtraCheckIn;
            ExtraCheckOut = entity.ExtraCheckOut;
        }
    }
}
