namespace MOROPO.ISCamaguey.Decisor.Production.Interop.API.Common.Models.Filter
{
    public sealed class ProductionQualityCheckFilterModel : Framework.Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.ProductionQualityCheck, System.Guid>
    {
        public string Parameter { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.ProductionQualityCheck, bool>> GetSelector()
        {
            return entity => entity.Author.Contact.Identity.Name.ToLower().Contains(Parameter.ToLower()) || entity.Author.Contact.Identity.LastName.ToLower().Contains(Parameter.ToLower());
        }
    }
}