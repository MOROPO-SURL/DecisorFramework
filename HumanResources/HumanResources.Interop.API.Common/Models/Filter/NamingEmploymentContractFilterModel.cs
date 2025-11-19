namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Filter
{
    public class NamingEmploymentContractFilterModel : Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.NamingEmploymentContract, System.Guid>
    {
        public System.Guid EmployeeId { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.NamingEmploymentContract, bool>> GetSelector()
        {
            return entity => entity.EmployeeId == EmployeeId;
        }
    }
}
