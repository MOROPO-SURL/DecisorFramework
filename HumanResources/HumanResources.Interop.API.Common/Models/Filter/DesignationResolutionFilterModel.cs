namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Filter
{
    public class DesignationResolutionFilterModel : Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.DesignationResolution, System.Guid>
    {
        public System.Guid StaffId { get; set; }

        public System.Guid WorkPositionId { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.DesignationResolution, bool>> GetSelector()
        {
            return entity => entity.StaffId == StaffId && entity.Vacant.WorkPositionId == WorkPositionId;
        }
    }
}