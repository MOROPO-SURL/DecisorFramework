namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Filter
{
    public class LegalClientSampleAnalysisServiceOrderFilterModel : Framework.Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.LegalClientSampleAnalysisServiceOrder, long>
    {
        public string Name { get; set; }

        public bool OnlyReadyForExecution { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.LegalClientSampleAnalysisServiceOrder, bool>> GetSelector()
        {
            if (OnlyReadyForExecution)
            {
                if (string.IsNullOrEmpty(Name)) return entity => entity.ExecutedAt == null && entity.ExecutedAt == null && entity.HandledAt != null;

                return entity => entity.ExecutedAt == null && entity.Contract.Client.Contact.Identity.Name.ToLower().Contains(Name.ToLower()) && entity.ExecutedAt == null && entity.HandledAt != null;
            }

            return entity => entity.ExecutedAt == null && entity.Contract.Client.Contact.Identity.Name.ToLower().Contains(Name.ToLower());
        }
    }
}