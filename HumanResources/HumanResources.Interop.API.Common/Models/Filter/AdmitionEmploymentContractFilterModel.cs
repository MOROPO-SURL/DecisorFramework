namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Filter
{
    public class AdmitionEmploymentContractFilterModel : Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.AdmitionEmploymentContract, System.Guid>
    {
        public System.Guid EmployeeId { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.AdmitionEmploymentContract, bool>> GetSelector()
        {
            return entity => entity.EmployeeId == EmployeeId;
        }
    }
}
