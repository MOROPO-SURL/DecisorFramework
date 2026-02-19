using System.Linq;

namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Filter
{
    public class WorkforceFilterModel : Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.Workforce, System.Guid>
    {
        public Domain.Interop.API.Common.Models.Display.OrganizationalUnitDisplayModel[] OrganizationalUnities { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.Workforce, bool>> GetSelector()
        {
            return entity => entity.OrganizationalUnities.Select(bridge => bridge.OrganizationalUnityId).SequenceEqual(OrganizationalUnities.Select(model => model.Id));
        }
    }
}
