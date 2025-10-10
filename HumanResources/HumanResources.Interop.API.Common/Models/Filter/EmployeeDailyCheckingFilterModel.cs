namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Filter
{
    public class EmployeeDailyCheckingFilterModel : Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.EmployeeDailyChecking, long>
    {
        public System.Guid EmployeeId { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.EmployeeDailyChecking, bool>> GetSelector()
        {
            return entity => entity.EmployeeId == EmployeeId && entity.Year == Year && entity.Month == Month;
        }
    }
}
