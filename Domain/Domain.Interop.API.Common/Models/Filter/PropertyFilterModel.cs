namespace MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Filter
{
    public class PropertyFilterModel : Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.Property, System.Guid>
    {
        public string Name { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.Property, bool>> GetSelector()
        {
            System.Linq.Expressions.Expression<System.Func<Persistence.Entities.Property, bool>> result = null;

            if (Name != null)
            {
                result = entity => entity.Name.Contains(Name);
            }

            if (result == null) return entity => true;

            return result;
        }
    }
}
