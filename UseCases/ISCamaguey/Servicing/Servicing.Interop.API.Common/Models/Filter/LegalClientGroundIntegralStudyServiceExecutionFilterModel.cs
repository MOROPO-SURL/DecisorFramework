using MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Filter
{
    public sealed class LegalClientGroundIntegralStudyServiceExecutionFilterModel : Framework.Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<LegalClientGroundIntegralStudyServiceExecution, System.Guid>
    {
        public string Parameter { get; set; }

        public System.Linq.Expressions.Expression<System.Func<LegalClientGroundIntegralStudyServiceExecution, bool>> GetSelector()
        {
            if (int.TryParse(Parameter, out int orderId)) return entity => entity.OrderId == orderId;

            return entity => entity.Order.Contract.Client.Contact.Identity.Name.ToLower().Contains(Parameter.ToLower());
        }
    }
}
