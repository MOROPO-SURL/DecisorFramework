namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Filter
{
    public class ProjectProposalFilterModel : Framework.Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.ProjectProposal, System.Guid>
    {
        public string Title { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.ProjectProposal, bool>> GetSelector()
        {
            return entity => entity.Title.ToLower().Contains(Title.ToLower());
        }
    }
}