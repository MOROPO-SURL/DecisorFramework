namespace MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Filter
{
    public class PersonContactFilterModel : Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.PersonContact, System.Guid>
    {
        public string Parameter { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.PersonContact, bool>> GetSelector()
        {
            return entity => entity.Identity.Name.ToLower().Contains(Parameter.ToLower());
        }
    }
}
