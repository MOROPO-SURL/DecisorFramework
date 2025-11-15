namespace MOROPO.Framework.Decisor.Inventory.Interop.API.Common.Models.Filter
{
    public class ClassificationFilterModel : Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.Classification, System.Guid>
    {
        public System.Guid ProductId { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.Classification, bool>> GetSelector()
        {
            return entity => entity.ProductId == ProductId;
        }
    }
}
