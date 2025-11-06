namespace MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Filter
{
    public class OrganizationContactFilterModel : Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.OrganizationContact, System.Guid>
    {
        public string Name { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.OrganizationContact, bool>> GetSelector()
        {
            return entity => entity.Identity.Name.ToLower().Contains(Name.ToLower());
        }
    }
}
