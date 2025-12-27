namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Filter
{
    public class CallForProposalFilterModel : Framework.Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.CallForProposal, System.Guid>
    {
        public string Title { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.CallForProposal, bool>> GetSelector()
        {
            return entity => entity.Title.ToLower().Contains(Title.ToLower());
        }
    }
}
