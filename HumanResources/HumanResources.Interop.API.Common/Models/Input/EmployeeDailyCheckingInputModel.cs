namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Input
{
    public class EmployeeDailyCheckingInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.EmployeeDailyChecking, long>
    {
        public long Id { get; set; }

        public System.Guid EmployeeId { get; set; }

        public int Day { get; set; }

        [System.ComponentModel.DataAnnotations.Range(1,12)]
        public int Month { get; set; }

        public int Year { get; set; }

        public System.TimeSpan CheckIn { get; set; }

        public System.TimeSpan? PartialCheckOut { get; set; }

        public System.TimeSpan? PartialChecIn { get; set; }

        public System.TimeSpan? CheckOut { get; set; }

        public System.TimeSpan? ExtraCheckIn { get; set; }

        public System.TimeSpan? ExtraCheckOut { get; set; }

        public Persistence.Entities.EmployeeDailyChecking Export()
        {
            var entity = new Persistence.Entities.EmployeeDailyChecking { EmployeeId = EmployeeId, Day = Day, Year = Year, Month = Month };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.EmployeeDailyChecking entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.EmployeeDailyChecking entity)
        {
            entity.CheckIn = CheckIn;
            entity.PartialCheckOut = PartialCheckOut;
            entity.PartialCheckIn = PartialChecIn;
            entity.CheckOut = CheckOut;
            entity.ExtraCheckIn = ExtraCheckIn;
            entity.ExtraCheckOut = ExtraCheckOut;
        }
    }
}
