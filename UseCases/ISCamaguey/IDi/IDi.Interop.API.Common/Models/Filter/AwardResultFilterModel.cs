using MOROPO.Framework.Guama.Core.Persistence.Presentation.Models.Filter.Contract;
using MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Filter
{
    public sealed class AwardResultFilterModel : IEntityFilterModel<AwardResult, System.Guid>
    {
        public string Parameter { get; set; }

        public System.Linq.Expressions.Expression<System.Func<AwardResult, bool>> GetSelector()
        {
            return entity => entity.Title.ToLower().Contains(Parameter) || entity.AwardKind.Name.ToLower().Contains(Parameter);
        }
    }
}