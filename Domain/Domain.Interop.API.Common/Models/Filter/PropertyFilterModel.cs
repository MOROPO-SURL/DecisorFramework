using MOROPO.Framework.Decisor.Core.Interop.API.Common.Extensions;

namespace MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Filter
{
    public class PropertyFilterModel : Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.Property, System.Guid>
    {
        public string Name { get; set; }

        public Persistence.Enumerations.PropertyAssignment[] Assignments { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.Property, bool>> GetSelector()
        {
            System.Linq.Expressions.Expression<System.Func<Persistence.Entities.Property, bool>> result = null;

            if (Assignments != null)
            {
                if (Assignments.Length == 0)
                {
                    result = entity => entity.Assignment == null;
                }
                else
                {
                    result = entity => entity.Assignment == Assignments[0];
                }

                for (int i = 1; i < Assignments.Length; i++)
                {
                    result.CombineForAndCondition(entity => entity.Assignment == Assignments[i]);
                }
            }

            if (Name != null)
            {
                if (result == null)
                {
                    result = entity => entity.Name.Contains(Name);
                }
                else
                {
                    result.CombineForAndCondition(entity => entity.Name.Contains(Name));
                }
            }

            if (result == null) return entity => true;

            return result;
        }
    }
}
