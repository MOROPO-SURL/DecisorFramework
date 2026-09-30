using MOROPO.Framework.Guama.Core.Persistence.Presentation.Models.Filter.Contract;
using MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Filter
{
    public sealed class ScientificTechnicalResultIntroductionFilterModel : IEntityFilterModel<ScientificTechnicalResultIntroduction, System.Guid>
    {
        public string Parameter { get; set; }

        public System.Linq.Expressions.Expression<System.Func<ScientificTechnicalResultIntroduction, bool>> GetSelector()
        {
            return entity => entity.Scenery.ToLower().Contains(Parameter.ToLower()) || entity.Result.Title.ToLower().Contains(Parameter.ToLower());
        }
    }
}
