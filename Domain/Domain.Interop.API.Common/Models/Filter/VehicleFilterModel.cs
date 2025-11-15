using MOROPO.Framework.Decisor.Core.Interop.API.Common.Extensions;

namespace MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Filter
{
    public class VehicleFilterModel : Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.Vehicle, System.Guid>
    {
        public string Parameter { get; set; }

        public Persistence.Enumerations.VehicleAssignment[] Assignments { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.Vehicle, bool>> GetSelector()
        {
            System.Linq.Expressions.Expression<System.Func<Persistence.Entities.Vehicle, bool>> result = null;

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

            if (Parameter != null)
            {
                if (result == null)
                {
                    result = entity => entity.Model.ToLower().Contains(Parameter.ToLower()) || entity.Brand.Name.ToLower().Contains(Parameter.ToLower());
                }
                else
                {
                    result.CombineForAndCondition(entity => entity.Model.ToLower().Contains(Parameter.ToLower()) || entity.Brand.Name.Contains(Parameter));
                }
            }

            if (result == null) return entity => true;

            return result;
        }
    }
}
