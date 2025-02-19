namespace MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Filter
{
    public class MunicipalityFilterModel : Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Guama.Location.Persistence.Entities.Municipality, System.Guid>
    {
        public System.Guid StateId { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Guama.Location.Persistence.Entities.Municipality, bool>> GetSelector()
        {
            return entity => entity.StateId == StateId;
        }
    }
}
