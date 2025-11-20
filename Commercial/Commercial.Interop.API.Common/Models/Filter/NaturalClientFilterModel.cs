namespace MOROPO.Framework.Decisor.Commercial.Interop.API.Common.Models.Filter
{
    public class NaturalClientFilterModel : Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.NaturalClient, System.Guid>
    {
        public string Parameter { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.NaturalClient, bool>> GetSelector()
        {
            return entity => entity.Contact.Identity.Name.ToLower().Contains(Parameter.ToLower()) || entity.Contact.Identity.LastName.ToLower().Contains(Parameter.ToLower());
        }
    }
}
