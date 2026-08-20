namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Filter
{
    public class DesignationEmploymentContractFilterModel : Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.DesignationEmploymentContract, System.Guid>
    {
        public System.Guid EmployeeId { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.DesignationEmploymentContract, bool>> GetSelector()
        {
            return entity => entity.EmployeeId == EmployeeId;
        }
    }
}
