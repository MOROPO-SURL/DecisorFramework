using MOROPO.Framework.Guama.Core.Persistence.Presentation.Models.Filter.Contract;
using MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Filter
{
    public sealed class PublicationResultFilterModel : IEntityFilterModel<PublicationResult, System.Guid>
    {
        public string Parameter { get; set; }

        public System.Linq.Expressions.Expression<System.Func<PublicationResult, bool>> GetSelector()
        {
            return entity => entity.Title.ToLower().Contains(Parameter.ToLower()) || entity.Project.Name.ToLower().Contains(Parameter.ToLower());
        }
    }
}