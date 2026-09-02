using MOROPO.Framework.Guama.Core.Persistence.Presentation.Models.Filter.Contract;
using MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Display.Contract;
using System.Linq.Expressions;

namespace MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Filter
{
    public sealed class CommonSampleFilterModel<TDisplayModel, TEntity> : IEntityFilterModel<TEntity, System.Guid>
        where TEntity : Persistence.Entities.Contract.AbstractSample
        where TDisplayModel : AbstractSampleDisplayModel<TEntity>
    {
        public bool IsPicked { get; set; }

        public bool IsHandled { get; set; }

        public Expression<System.Func<TEntity, bool>> GetSelector()
        {
            return entity => entity.PickedAt != null == IsPicked && entity.HandledAt != null == IsHandled;
        }
    }
}