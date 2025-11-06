namespace MOROPO.Framework.Decisor.Commercial.Interop.API.Common.Models.Filter
{
    public class LegalClientFilterModel : Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.LegalClient, System.Guid>
    {
        public string Name { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.LegalClient, bool>> GetSelector()
        {
            return entity => entity.Contact.Identity.Name.ToLower().Contains(Name.ToLower());
        }
    }
}
