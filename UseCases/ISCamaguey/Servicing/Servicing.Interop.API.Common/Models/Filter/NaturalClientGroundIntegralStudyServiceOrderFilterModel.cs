
namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Filter
{
    public class NaturalClientGroundIntegralStudyServiceOrderFilterModel : Framework.Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.NaturalClientGroundIntegralStudyServiceOrder, long>
    {
        public string Name { get; set; }

        public bool OnlyReadyForExecution { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.NaturalClientGroundIntegralStudyServiceOrder, bool>> GetSelector()
        {
            if (OnlyReadyForExecution)
            {
                if (string.IsNullOrEmpty(Name)) return entity => entity.ExecutedAt == null && entity.ExecutedAt == null;

                return entity => entity.ExecutedAt == null && entity.Contract.Client.Contact.Identity.Name.ToLower().Contains(Name.ToLower()) && entity.ExecutedAt == null;
            }

            return entity => entity.ExecutedAt == null && entity.Contract.Client.Contact.Identity.Name.ToLower().Contains(Name.ToLower());
        }
    }
}
