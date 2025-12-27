namespace MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Filter
{
    public class OrganizationalUnityFilterModel : Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.OrganizationalUnity, System.Guid>
    {
        public string Name { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.OrganizationalUnity, bool>> GetSelector()
        {
            return entity => entity.Name.ToLower().Contains(Name.ToLower());
        }
    }
}
