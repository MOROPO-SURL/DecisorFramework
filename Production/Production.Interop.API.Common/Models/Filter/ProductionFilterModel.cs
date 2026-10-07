namespace MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Filter
{
    public class ProductionFilterModel : Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.Production, System.Guid>
    {
        public string Param { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.Production, bool>> GetSelector()
        {
            return entity => entity.Order.Elaboration.Name.ToLower().Contains(Param.ToLower()) || entity.Order.Elaboration.Product.Name.ToLower().Contains(Param.ToLower());
        }
    }
}