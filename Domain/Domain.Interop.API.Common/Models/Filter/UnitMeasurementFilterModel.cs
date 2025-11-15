namespace MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Filter
{
    public class UnitMeasurementFilterModel : Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.UnitMeasurement, System.Guid>
    {
        public string Parameter { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.UnitMeasurement, bool>> GetSelector()
        {
            return entity => entity.Symbol.ToLower().Contains(Parameter.ToLower()) || entity.Name.ToLower().Contains(Parameter.ToLower());
        }
    }
}