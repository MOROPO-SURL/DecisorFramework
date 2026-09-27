
namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Filter
{
    public class NaturalClientTrainingServiceOrderFilterModel : Framework.Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.NaturalClientTrainingServiceOrder, long>
    {
        public string Name { get; set; }

        public bool OnlyReadyForExecution { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.NaturalClientTrainingServiceOrder, bool>> GetSelector()
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
