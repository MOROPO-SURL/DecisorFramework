namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Filter
{
    public class NamingResolutionFilterModel : Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.NamingResolution, System.Guid>
    {
        public System.Guid StaffId { get; set; }

        public System.Guid WorkPositionId { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.NamingResolution, bool>> GetSelector()
        {
            return entity => entity.AdmitionPropousal.OcupationCandidate.Postulation.StaffId == StaffId && entity.AdmitionPropousal.OcupationCandidate.Postulation.Vacant.WorkPositionId == WorkPositionId;
        }
    }
}