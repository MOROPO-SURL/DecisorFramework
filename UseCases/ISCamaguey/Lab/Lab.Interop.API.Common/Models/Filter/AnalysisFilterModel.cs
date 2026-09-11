namespace MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Filter
{
    public sealed class AnalysisFilterModel : Framework.Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.Analysis, System.Guid>
    {
        public System.Guid SampleId { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.Analysis, bool>> GetSelector()
        {
            return entity => entity.SampleId == SampleId;
        }
    }
}