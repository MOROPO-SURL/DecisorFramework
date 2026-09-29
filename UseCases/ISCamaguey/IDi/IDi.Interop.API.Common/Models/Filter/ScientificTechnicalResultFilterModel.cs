using MOROPO.Framework.Guama.Core.Persistence.Presentation.Models.Filter.Contract;
using MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Filter
{
    public sealed class ScientificTechnicalResultFilterModel : IEntityFilterModel<ScientificTechnicalResult, System.Guid>
    {
        public string Parameter { get; set; }

        public System.Linq.Expressions.Expression<System.Func<ScientificTechnicalResult, bool>> GetSelector()
        {
            return entity => entity.Title.ToLower().Contains(Parameter) || entity.Reference.ToLower().Contains(Parameter) || entity.Kind.Name.ToLower().Contains(Parameter);
        }
    }
}