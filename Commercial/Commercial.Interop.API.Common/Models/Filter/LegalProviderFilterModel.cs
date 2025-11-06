namespace MOROPO.Framework.Decisor.Commercial.Interop.API.Common.Models.Filter
{
    public class LegalProviderFilterModel : Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.LegalProvider, System.Guid>
    {
        public string Name { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.LegalProvider, bool>> GetSelector()
        {
            return entity => entity.Contact.Identity.Name.Contains(Name.ToLower());
        }
    }
}
