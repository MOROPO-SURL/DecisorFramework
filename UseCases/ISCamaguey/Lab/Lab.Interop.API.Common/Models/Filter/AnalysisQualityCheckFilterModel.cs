namespace MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Filter
{
    public sealed class AnalysisQualityCheckFilterModel : Framework.Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.AnalysisQualityCheck, System.Guid>
    {
        public string Parameter { get; set; }

        public System.Guid? AnalysisId { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.AnalysisQualityCheck, bool>> GetSelector()
        {
            if (string.IsNullOrEmpty(Parameter))
            {
                return entity => entity.AnalysisId == AnalysisId;
            }

            if (AnalysisId == null)
            {
                return entity => entity.Author.Contact.Identity.Name.ToLower().Contains(Parameter.ToLower()) || entity.Author.Contact.Identity.LastName.ToLower().Contains(Parameter.ToLower());
            }

            return entity => entity.AnalysisId == AnalysisId && entity.Author.Contact.Identity.Name.ToLower().Contains(Parameter.ToLower()) || entity.Author.Contact.Identity.LastName.ToLower().Contains(Parameter.ToLower());
        }
    }
}