namespace MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Filter
{
    public sealed class AnalysisQualityCheckFilterModel : Framework.Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.AnalysisQualityCheck, System.Guid>
    {
        public System.Guid AnalysisId { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.AnalysisQualityCheck, bool>> GetSelector()
        {
            return entity => entity.AnalysisId == AnalysisId;
        }
    }
}