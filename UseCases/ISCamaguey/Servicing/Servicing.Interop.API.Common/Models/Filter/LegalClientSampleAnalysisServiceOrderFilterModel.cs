namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Filter
{
    public class LegalClientSampleAnalysisServiceOrderFilterModel : Framework.Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.LegalClientSampleAnalysisServiceOrder, long>
    {
        public string Name { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.LegalClientSampleAnalysisServiceOrder, bool>> GetSelector()
        {
            return entity => entity.Contract.Client.Contact.Identity.Name.ToLower().Contains(Name.ToLower());
        }
    }
}