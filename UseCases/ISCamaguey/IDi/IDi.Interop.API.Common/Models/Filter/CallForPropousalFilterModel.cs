namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Filter
{
    public class CallForPropousalFilterModel : Framework.Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.CallForPropousal, System.Guid>
    {
        public string Title { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.CallForPropousal, bool>> GetSelector()
        {
            return entity => entity.Title.ToLower().Contains(Title.ToLower());
        }
    }
}
