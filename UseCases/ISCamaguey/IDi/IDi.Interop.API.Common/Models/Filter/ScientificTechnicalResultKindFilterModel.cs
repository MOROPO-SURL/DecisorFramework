using MOROPO.Framework.Guama.Core.Persistence.Presentation.Models.Filter.Contract;
using MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Filter
{
    public sealed class ScientificTechnicalResultKindFilterModel : IEntityFilterModel<ScientificTechnicalResultKind, System.Guid>
    {
        public string Name { get; set; }

        public System.Linq.Expressions.Expression<System.Func<ScientificTechnicalResultKind, bool>> GetSelector()
        {
            return entity => entity.Name.ToLower().Contains(Name.ToLower());
        }
    }
}
