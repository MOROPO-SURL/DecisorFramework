namespace MOROPO.Framework.Decisor.Financial.Interop.API.Common.Models.Filter
{
    public class CostCenterFilterModel : Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.CostCenter, System.Guid>
    {
        public System.Guid StructureId { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.CostCenter, bool>> GetSelector()
        {
            return entity => entity.StructureId == StructureId;
        }
    }
}
