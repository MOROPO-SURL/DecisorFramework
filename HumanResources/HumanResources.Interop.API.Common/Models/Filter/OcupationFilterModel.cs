namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Filter
{
    public class OcupationFilterModel : Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.Ocupation, System.Guid>
    {
        public System.Guid? StaffId { get; set; }

        public System.Guid? WorkforceId { get; set; }

        public System.Guid? EmployeeId { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.Ocupation, bool>> GetSelector()
        {
            if (EmployeeId == null) return entity => entity.StaffId == StaffId && (entity.Vacant.WorkforceOrganizationalUnit.WorkforceId == WorkforceId || (entity.Staff.MainWorkforceId == WorkforceId));
            
            return entity => entity.Contract.EmployeeId == EmployeeId;
        }
    }
}