using MOROPO.ISCamaguey.Decisor.Recommending.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.Recommending.Interop.API.Common.Models.Filter
{
    public sealed class RecomendationReportFilterModel : Framework.Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<RecomendationReport, System.Guid>
    {
        public string Parameter { get; set; }

        public System.Linq.Expressions.Expression<System.Func<RecomendationReport, bool>> GetSelector()
        {
            return entity => entity.Title.ToLower().Contains(Parameter.ToLower()) || entity.Reference.ToLower().Contains(Parameter.ToLower());
        }
    }
}
