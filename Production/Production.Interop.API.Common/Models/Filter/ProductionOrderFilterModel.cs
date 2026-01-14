namespace MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Filter
{
    public class ProductionOrderFilterModel : Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.ProductionOrder, System.Guid>
    {
        public string Param { get; set; }

        public bool HasProduction { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.ProductionOrder, bool>> GetSelector()
        {
            if (string.IsNullOrEmpty(Param)) return entity => entity.Production != null == HasProduction;

            return entity => entity.Production != null == HasProduction && (entity.Elaboration.Name.ToLower().Contains(Param.ToLower()) || entity.Elaboration.Product.Name.ToLower().Contains(Param.ToLower()));
        }
    }
}