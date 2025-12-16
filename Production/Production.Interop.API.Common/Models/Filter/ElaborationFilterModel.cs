namespace MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Filter
{
    public class ElaborationFilterModel : Framework.Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.Elaboration, System.Guid>
    {
        public string Param { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.Elaboration, bool>> GetSelector()
        {
            return entity => entity.Name.ToLower().Contains(Param.ToLower()) || entity.Product.Name.ToLower().Contains(Param.ToLower());
        }
    }
}