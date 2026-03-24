namespace MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Filter
{
    public class LegalBusinessKindFilterModel : Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.LegalBusinessKind, System.Guid>
    {
        public string Parameter { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.LegalBusinessKind, bool>> GetSelector()
        {
            return entity => entity.Name.ToLower().Contains(Parameter.ToLower());
        }
    }
}
