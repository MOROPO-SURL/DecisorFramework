namespace MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Filter
{
    public class ResultFilterModel : Framework.Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.ActionIndicatorResult, long>
    {
        public System.Guid ObjectiveId { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.ActionIndicatorResult, bool>> GetSelector()
        {
            return entity => entity.Indicator.Action.Proyection.ObjectiveId == ObjectiveId;
        }
    }
}
