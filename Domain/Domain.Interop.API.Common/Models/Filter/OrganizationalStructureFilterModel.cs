namespace MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Filter
{
    public class OrganizationalStructureFilterModel : Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.OrganizationalStructure, System.Guid>
    {
        public string Name { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.OrganizationalStructure, bool>> GetSelector()
        {
            return entity => entity.Name.ToLower().Contains(Name.ToLower());
        }
    }
}
