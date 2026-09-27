using MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Filter
{
    public sealed class LegalClientTrainingServiceExecutionFilterModel : Framework.Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<LegalClientTrainingServiceExecution, System.Guid>
    {
        public string Parameter { get; set; }

        public System.Linq.Expressions.Expression<System.Func<LegalClientTrainingServiceExecution, bool>> GetSelector()
        {
            if (int.TryParse(Parameter, out int orderId)) return entity => entity.OrderId == orderId;

            return entity => entity.Order.Contract.Client.Contact.Identity.Name.ToLower().Contains(Parameter.ToLower());
        }
    }
}
